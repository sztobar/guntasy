using UnityEngine;
using System.Collections;
using Enemies.Projectile;

namespace Enemies.Weapon {
  public class EnemyWeapon : BaseEnemyWeapon {

    private static Quaternion ROTATION_FIX = Quaternion.Inverse(Quaternion.Euler(0, 0, 180));

    [SerializeField]
    private EnemyWeaponAnimator animator;

    [SerializeField]
    private ProjectileSpawnable projectilePrefab;

    [SerializeField]
    private AudioSource shootSound;

    private Quaternion initialRotation;

    protected override void EnemyWeaponAwake() {
      base.EnemyWeaponAwake();
      initialRotation = transform.localRotation;
    }

    public override void ResetAim() {
      transform.localRotation = initialRotation;
    }

    public override void Shoot() {
      if (shootSound) {
        shootSound.Play();
      }
      var projectile = projectilePrefab.Spawn(projectilePrefab.transform.position, transform.rotation * ROTATION_FIX);
      animator.PlayShoot();
    }
  }
}