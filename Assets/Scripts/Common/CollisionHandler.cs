using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : BaseCollider {

  public Action<RaycastHit2D> OnTileCollision { get; set; } = delegate { };
  public Action<RaycastHit2D> OnCharacterCollision { get; set; } = delegate { };
  public Action<RaycastHit2D> OnProjectileCollision { get; set; } = delegate { };
  public Action<RaycastHit2D> OnExplosionCollision { get; set; } = delegate { };

  public void SetCallbacks(ICollisionHandler handler) {
    OnTileCollision += handler.HandleTileCollision;
    OnCharacterCollision += handler.HandleCharacterCollision;
    OnProjectileCollision += handler.HandleProjectileCollision;
    OnExplosionCollision += handler.HandleExplosionCollision;
  }

  private void Awake() {
    OnCollision += HandleCollision;
  }

  private void HandleCollision(RaycastHit2D hit) {
    var layer = hit.transform.gameObject.layer;
    switch (layer) {
      case UnityConstants.Layers.Collision:
        OnTileCollision(hit);
        return;
      case UnityConstants.Layers.Player:
      case UnityConstants.Layers.Enemy:
        OnCharacterCollision(hit);
        return;
      case UnityConstants.Layers.Player_Projectile:
      case UnityConstants.Layers.EnemyProjectile:
        OnProjectileCollision(hit);
        return;
      case UnityConstants.Layers.Explosion:
        OnExplosionCollision(hit);
        return;
    }
  }
}
