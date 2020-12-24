using UnityEngine;
using System.Collections.Generic;
using System;
using Enums;

namespace Explosion {
  public class BaseExplosionCollider : MonoBehaviour {

    [SerializeField]
    private BaseCollider baseCollider;

    private HashSet<Transform> hitTargets = new HashSet<Transform>();
    private float damage;

    public void SetDamage(float newDamage) {
      damage = newDamage;
    }

    private void Awake() {
      baseCollider.OnCollision += HandleCollision;
      baseCollider.ColliderDisable();
    }

    private void HandleCollision(RaycastHit2D hit) {
      if (!hitTargets.Contains(hit.transform)) {
        OnTargetHit(hit);
      }
    }

    public void TurnOnCollision() {
      if (damage > 0) {
        baseCollider.ColliderEnable();
      }
    }

    private void OnTargetHit(RaycastHit2D hit) {
      hitTargets.Add(hit.transform);

      IDamagable collisionHandler = hit.transform.GetComponent<IDamagable>();
      if (collisionHandler != null) {
        collisionHandler.TakeDamage(damage, DamageType.Explosion);
      }
    }

      //int layer = hit.transform.gameObject.layer;
      //switch (layer) {
      //  case UnityConstants.Layers.Enemy:
      //    OnEnemyHit(hit);
      //    break;
      //  case UnityConstants.Layers.Player:
      //    OnPlayerHit(hit);
      //    break;
      //  case UnityConstants.Layers.Player_Projectile:
      //    OnProjectileHit(hit);
      //    break;
      //}

    //private void OnPlayerHit(RaycastHit2D hit) {
    //  IDamagable collisionHandler = hit.transform.GetComponent<IDamagable>();
    //  collisionHandler.TakeDamage(damage);
    //}

    //private void OnEnemyHit(RaycastHit2D hit) {
    //  IDamagable collisionHandler = hit.transform.GetComponent<IDamagable>();
    //  collisionHandler.TakeDamage(damage);
    //}

    //private void OnProjectileHit(RaycastHit2D hit) {
    //  IDamagable collisionHandler = hit.transform.GetComponent<IDamagable>();
    //  if (collisionHandler != null) {
    //    collisionHandler.TakeDamage(damage);
    //  }
    //}
  }
}