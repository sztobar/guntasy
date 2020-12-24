using UnityEngine;
using Kite;
using Managers;

public class GunController : BaseWeaponController {

  [SerializeField]
  private GunDI di;

  private IWeaponAimHandler aimHandler;
  private IWeaponAmmoHandler ammoHandler;
  private IWeaponFireHandler fireHandler;

  public override IWeaponDI DI => di;

  public override Direction3 GetDirection3() {
    return aimHandler.GetDirection3();
  }

  public override bool LookAt(Vector2 mousePosition) {
    return aimHandler.LookAt(mousePosition);
  }

  public override void PrimaryActionHold(bool hold) {
    if (hold && fireHandler.HasAutoFire()) {
      Fire();
    }
  }

  public override void Inject(IWeaponDI di) {
    aimHandler = di.AimHandler;
    ammoHandler = di.AmmoHandler;
    fireHandler = di.FireHandler;
  }

  public override void PrimaryActionPress() {
    Fire();
  }

  private void Fire() {
    if (fireHandler.CanFire() && ammoHandler.HasAmmo()) {
      fireHandler.Fire();
      ammoHandler.UseAmmo();
    }
  }

  public override void Reload() {
    ammoHandler.Reload();
  }

  public override void SecondActionHold(bool hold) {
    aimHandler.FocusAim(hold);
  }

  public override void SecondActionPress() { }

  private void Update() {
    PlayerManager.Instance.AmmoPercentage = ammoHandler.GetAmmoPercentage();
  }
}
