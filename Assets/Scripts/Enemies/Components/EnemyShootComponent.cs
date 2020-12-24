using UnityEngine;
using Enemies.Weapon;
using Kite;

namespace Enemies.Components {
  public class EnemyShootComponent : MonoBehaviour {

    [SerializeField]
    private BaseEnemyWeapon weapon;

    [SerializeField]
    [Tooltip("Time between shoots")]
    private float shootInterval;

    [SerializeField]
    private HorizontalFlipComponent directionComponent;

    private bool hasLookTarget;
    private Vector2 lookTarget;
    private float timeToShoot;

    public Vector2 GetLookDirection() {
      if (hasLookTarget) {
        return lookTarget - (Vector2)transform.position;
      } else {
        return Vector2.left;
      }
    }

    public void ResetAim() {
      hasLookTarget = false;
      weapon.ResetAim();
    }

    public virtual void AimAt(Vector2 target) {
      hasLookTarget = true;
      lookTarget = target;
      weapon.AimAt(target);
      // todo refactor pls
      if (directionComponent) {
        directionComponent.Direction = Direction2Helpers.FromFloat(GetLookDirection().x);
      }
    }

    public virtual void Shoot() {
      if (timeToShoot > 0) {
        return;
      }
      PerformShoot();
    }

    private void PerformShoot() {
      timeToShoot = shootInterval;
      weapon.Shoot();
    }

    private void Update() {
      if (timeToShoot > 0) {
        timeToShoot -= Time.deltaTime;
      }
    }

  }
}