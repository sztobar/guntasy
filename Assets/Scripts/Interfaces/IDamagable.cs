using UnityEngine;
using System.Collections;
using Enums;

public interface IDamagable {

  bool TakeDamage(float damage, DamageType type);
}
