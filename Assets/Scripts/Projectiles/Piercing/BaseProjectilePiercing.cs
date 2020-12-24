using UnityEngine;
using System.Collections;

public abstract class BaseProjectilePiercing : MonoBehaviour {

  [SerializeField] private BaseProjectileDamage damage;

  public abstract bool CanHit(RaycastHit2D hit);
  public abstract void PerformHit(RaycastHit2D hit);
  public abstract bool ShouldBeDestroyed();

  public bool Inflict(RaycastHit2D hit) {
    var damagable = hit.transform.GetComponent<IDamagable>();
    if (damagable != null && CanHit(hit)) {
      bool damageEffective = damagable.TakeDamage(damage.GetDamage(), DamageType.Projectile);
      PerformHit(hit);
      if (damageEffective && ShouldBeDestroyed()) {
        return true;
      }
    }
    return false;
  }
}
