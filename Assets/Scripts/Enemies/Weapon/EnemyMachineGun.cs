using UnityEngine;
using System.Collections;

namespace Enemies.Weapon {
  public class EnemyMachineGun : BaseEnemyWeapon {

    [SerializeField]
    private EnemyMachineGunBarrel leftBarrel;

    [SerializeField]
    private EnemyMachineGunBarrel rightBarrel;

    [SerializeField]
    private AudioSource shootSound;

    public override void ResetAim() {
      leftBarrel.ResetAim();
      rightBarrel.ResetAim();
    }

    public override void AimAt(Vector2 target) {
      leftBarrel.AimAt(target);
      rightBarrel.AimAt(target);
    }

    public override void Shoot() {
      shootSound.Play();
      leftBarrel.Shoot();
      rightBarrel.Shoot();
    }
  }
}