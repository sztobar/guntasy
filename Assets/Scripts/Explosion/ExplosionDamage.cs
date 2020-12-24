using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {

  private float damage;

  public float GetDamage() {
    return damage;
  }

  public virtual void SetDamage(float newDamage) {
    damage = newDamage;
  }
}
