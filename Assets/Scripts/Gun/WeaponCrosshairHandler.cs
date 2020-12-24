using UnityEngine;

public class WeaponCrosshairHandler : MonoBehaviour, IWeaponInjectable {

  [SerializeField] CursorMode cursorMode;
  [SerializeField] Sprite idle;
  [SerializeField] Sprite fire;

  private WeaponStateMachine stateMachine;
  private AimCursor aimCursor;
  private CursorManager cursorManager;

  public void Inject(IWeaponDI di) {
    stateMachine = di.StateMachine;
    stateMachine.OnWeaponEvent += OnWeaponEvent;
  }

  private void Start() {
    cursorManager = CursorManager.Instance;
    aimCursor = cursorManager.AimCursor;
    cursorManager.SetMode(cursorMode);
    SetIdle();
  }

  private void SetFire() {
    aimCursor.SetCursor(fire);
  }

  private void SetIdle() {
    aimCursor.SetCursor(idle);
  }

  public void SetReload() {
    cursorManager.StartReload();
  }

  private void ResetReload() {
    cursorManager.StopReload();
  }

  private void OnWeaponEvent(WeaponEvent weaponEvent) {
    switch(weaponEvent) {
      case WeaponEvent.FireStart:
        SetFire();
        break;
      case WeaponEvent.ReloadStart:
        SetReload();
        break;
      case WeaponEvent.FireEnd:
        SetIdle();
        break;
      case WeaponEvent.ReloadEnd:
        ResetReload();
        SetIdle();
        break;
    }
  }

  //private void OnEnable() {
  //  cursorManager = CursorManager.Instance;
  //  aimCursor = cursorManager.AimCursor;
  //}

  private void OnDisable() {
    stateMachine.OnWeaponEvent -= OnWeaponEvent;
  }
}
