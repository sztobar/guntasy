using UnityEngine;
using System.Collections;

namespace Enemies.Weapon {
  public abstract class BaseEnemyWeapon : MonoBehaviour {

    private static Quaternion FRONT_ROTATION_FIX = Quaternion.Inverse(Quaternion.Euler(0, 0, -90));

    private void Awake() {
      EnemyWeaponAwake();
    }

    protected virtual void EnemyWeaponAwake() { }

    public virtual void ResetAim() { }

    public virtual void AimAt(Vector2 target) {
      Vector2 directionVector = (Vector2)transform.position - target;
      Quaternion aimRotation = Quaternion.LookRotation(transform.forward, directionVector) * FRONT_ROTATION_FIX;
      transform.rotation = aimRotation;
    }

    public abstract void Shoot();
  }
}