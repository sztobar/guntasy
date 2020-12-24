using UnityEngine;

public class WeaponAmmoHandler : MonoBehaviour, IWeaponAmmoHandler {

  [SerializeField] private float ammo;
  [SerializeField] private ShellSpawnable reloadShell;

  private WeaponStateMachine stateMachine;
  private IWeaponAnimator gunAnimator;
  private float currentAmmo;
  private float reloadPercentage;

  public bool HasAmmo() => currentAmmo > 0;

  public void Inject(IWeaponDI di) {
    gunAnimator = di.WeaponAnimator;
    stateMachine = di.StateMachine;
    stateMachine.OnWeaponEvent += OnWeaponEvent;
  }

  private void OnDisable() {
    if (stateMachine != null) {
      stateMachine.OnWeaponEvent -= OnWeaponEvent;
    }
  }

  private void OnWeaponEvent(WeaponEvent weaponEvent) {
    switch (weaponEvent) {
      case WeaponEvent.ReloadStart:
        OnReloadStart();
        break;
      case WeaponEvent.ReloadEnd:
        OnReloadEnd();
        break;
    }
  }

  private void OnReloadEnd() {
    currentAmmo = ammo;
  }

  private void OnReloadStart() {
    reloadPercentage = 0;
  }

  public void SetReloadPercentage(float percentage) {
    reloadPercentage = percentage;
  }

  public float GetAmmoPercentage() {
    if (stateMachine.IsReloading()) {
      return reloadPercentage;
    } else {
      return currentAmmo / ammo;
    }
  }

  public void UseAmmo() {
    currentAmmo -= 1;
    if (currentAmmo == 0) {
      ReloadImplementation();
    }
  }

  public void Reload() {
    bool hasFullAmmo = currentAmmo == ammo;
    if (!hasFullAmmo && !stateMachine.IsReloading()) {
      ReloadImplementation();
    }
  }

  private void ReloadImplementation() {
    gunAnimator.PlayReload();
    SpawnShell();
  }

  private void SpawnShell() {
    if (reloadShell) {
      reloadShell.Spawn();
    }
  }

  private void Awake() {
    currentAmmo = ammo;
  }
}
