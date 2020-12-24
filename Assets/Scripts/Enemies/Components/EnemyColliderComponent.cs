using UnityEngine;
using System.Collections;
using System;
using Enums;

namespace Enemies.Components {
  public class EnemyColliderComponent : MonoBehaviour, IDamagable {

    public Action<float, DamageType> OnTakeDamage { get; set; } = delegate { };

    public bool TakeDamage(float damage, DamageType type) {
      OnTakeDamage(damage, type);
      return true;
    }
  }
}