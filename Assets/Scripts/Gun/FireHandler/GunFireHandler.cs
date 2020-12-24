using UnityEngine;

public class GunFireHandler : BaseWeaponFileHandler {

  [SerializeField] private float shootInterval;
  [SerializeField] private bool autoFire;
  [SerializeField] private ProjectileSpawnable projectilePrefab;
  [SerializeField] private ShellSpawnable shootShell;

  private CameraEmitShake cameraEmitShake;
  private IWeaponAimHandler aimHandler;
  private IWeaponAnimator gunAnimator;
  private IInaccuracyHandler inaccuracyHandler;
  private IWeaponRecoil weaponRecoil;
  private WeaponSoundHandler soundHandler;
  private float shootIntervalTimeLeft;
  private Transform playerTransform;

  public override bool HasAutoFire() {
    return autoFire == true;
  }

  public override bool CanFire() {
    return shootIntervalTimeLeft <= 0 && !gunAnimator.IsReloading();
  }

  public override void AutoFire() {
    if (autoFire) {
      Fire();
    }
  }

  public override void Fire() {
    if (shootIntervalTimeLeft <= 0) {
      FireImplementation();
    }
  }

  private void FireImplementation() {
    cameraEmitShake.EmitShake(playerTransform.position);
    Quaternion projectileRotation = aimHandler.GetFireRotation();
    inaccuracyHandler.GenerateInaccuracy();
    projectileRotation *= inaccuracyHandler.Inaccuracy;

    ProjectileSpawnable projectile = projectilePrefab.Spawn(projectilePrefab.transform.position, projectileRotation);

    inaccuracyHandler.PerformFire();
    weaponRecoil.PerformFire();

    shootIntervalTimeLeft = shootInterval;
    gunAnimator.PlayFire();
    soundHandler.BindProjectileToSound(projectile);
    if (shootShell) {
      shootShell.Spawn(shootShell.transform.position, transform.rotation);
    }
  }

  public override void Inject(IWeaponDI di) {
    playerTransform = di.PlayerDI.transform;
    cameraEmitShake = di.CameraEmitShake;
    gunAnimator = di.WeaponAnimator;
    aimHandler = di.AimHandler;
    soundHandler = di.SoundHandler;
    inaccuracyHandler = di.InaccuracyHandler;
    weaponRecoil = di.WeaponRecoil;
  }

  private void Update() {
    if (shootIntervalTimeLeft > 0) {
      shootIntervalTimeLeft -= Time.deltaTime;
    }
  }
}
