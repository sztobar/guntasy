using UnityEngine;

public class GunAnimator : MonoBehaviour, IWeaponAnimator {

  static readonly int ReloadHash = Animator.StringToHash("Reload");
  static readonly int DodgeLeapHash = Animator.StringToHash("DodgeLeap");
  static readonly int DodgeRollHash = Animator.StringToHash("DodgeRoll");
  static readonly int FireHash = Animator.StringToHash("Fire");

  [SerializeField] private Animator animator;

  private WeaponStateMachine stateMachine;
  private IWeaponAmmoHandler ammoHandler;
  private PlayerDodgeComponent playerDodgeComponent;

  public void PlayFire() {
    animator.SetTrigger(FireHash);
  }

  public void PlayReload() {
    animator.SetBool(ReloadHash, true);
  }

  public void PlayDodgeLeap() {
    animator.SetTrigger(DodgeLeapHash);
  }

  public void PlayDodgeRoll() {
    animator.SetTrigger(DodgeRollHash);
  }

  public void Inject(IWeaponDI di) {
    InjectWeaponSMBs(di);
    playerDodgeComponent = di.PlayerDI.GameplayController.Dodge;
    ammoHandler = di.AmmoHandler;
    stateMachine = di.StateMachine;
    stateMachine.OnWeaponEvent += OnWeaponEvent;
  }

  private void InjectWeaponSMBs(IWeaponDI di) {
    BaseWeaponSMB[] weaponSMBs = animator.GetBehaviours<BaseWeaponSMB>();
    for (int i = 0; i < weaponSMBs.Length; i++) {
      weaponSMBs[i].Inject(di);
    }
  }

  private void OnWeaponEvent(WeaponEvent weaponEvent) {
    switch (weaponEvent) {
      case WeaponEvent.ReloadStart:
        animator.SetBool(ReloadHash, false);
        break;
      case WeaponEvent.DodgeRollEnd:
        playerDodgeComponent.OnDodgeRollAnimationEnded();
        if (!ammoHandler.HasAmmo()) {
          PlayReload();
        }
        break;
    }
  }

  private void OnDisable() {
    if (stateMachine != null) {
      stateMachine.OnWeaponEvent -= OnWeaponEvent;
    }
  }

  public bool IsReloading() {
    return stateMachine.IsReloading();
  }
}
