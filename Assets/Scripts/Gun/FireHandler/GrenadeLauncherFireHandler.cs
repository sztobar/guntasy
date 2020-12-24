using UnityEngine;

public class GrenadeLauncherFireHandler : BaseWeaponFileHandler {

  [SerializeField] private float shootInterval;
  [SerializeField] private ProjectileSpawnable projectilePrefab;
  [SerializeField] private ShellSpawnable shootShell;

  private IWeaponAimHandler aimHandler;
  private IWeaponAnimator gunAnimator;
  private IWeaponRecoil weaponRecoil;
  private WeaponSoundHandler soundHandler;
  private float shootIntervalTimeLeft;

  public override bool HasAutoFire() {
    return false;
  }

  public override bool CanFire() {
    return shootIntervalTimeLeft <= 0 && !gunAnimator.IsReloading();
  }

  public override void AutoFire() { }

  public override void Fire() {
    if (shootIntervalTimeLeft <= 0) {
      FireImplementation();
    }
  }

  private void FireImplementation() {
    Vector2 target = aimHandler.MousePosition;
    ProjectileSpawnable projectile = projectilePrefab.Spawn(projectilePrefab.transform.position, aimHandler.GetFireRotation());

    weaponRecoil.PerformFire();

    shootIntervalTimeLeft = shootInterval;
    gunAnimator.PlayFire();
    //soundHandler.BindProjectileToSound(projectile);
    if (shootShell) {
      shootShell.Spawn(shootShell.transform.position, transform.rotation);
    }
  }

  public override void Inject(IWeaponDI di) {
    gunAnimator = di.WeaponAnimator;
    aimHandler = di.AimHandler;
    soundHandler = di.SoundHandler;
    weaponRecoil = di.WeaponRecoil;
  }

  private void Update() {
    if (shootIntervalTimeLeft > 0) {
      shootIntervalTimeLeft -= Time.deltaTime;
    }
  }
}
