﻿using UnityEngine;

public class GrenadeProjectileController : MonoBehaviour, IDamagable {

  [SerializeField]
  private BaseCollisionEmitter collisionEmitter;

  [SerializeField]
  private EmitDestructionItem emitDestructionItem;

  [SerializeField]
  private ExplosionSpawnable explosionPrefab;

  [SerializeField]
  private BaseProjectileDamage projectileDamage;

  public void HandleCollision(RaycastHit2D hit, CollisionType type) {
    if (type != CollisionType.Projectile) {
      DestroyAndExplode();
    }
  }

  private void DestroyAndExplode() {
    if (!emitDestructionItem.IsDestroyed) {
      explosionPrefab.Spawn(transform.position, projectileDamage.GetDamage());
      emitDestructionItem.DestroyGameObject();
    }
  }

  public bool TakeDamage(float damage, DamageType type) {
    DestroyAndExplode();
    return true;
  }

  private void Awake() {
    collisionEmitter.OnCollision += HandleCollision;
  }

  void FixedUpdate() {
    collisionEmitter.Cast();
  }
}
