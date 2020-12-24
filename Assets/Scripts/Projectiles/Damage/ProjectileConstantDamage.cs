using UnityEngine;
using System.Collections;

public class ProjectileConstantDamage : BaseProjectileDamage {

  [SerializeField]
  private float damage;

  public override float GetDamage() {
    return damage;
  }
}
