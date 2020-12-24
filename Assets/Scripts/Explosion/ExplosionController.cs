using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

[RequireComponent(typeof(BaseCollisionEmitter))]
[RequireComponent(typeof(ExplosionDamage))]
public class ExplosionController : MonoBehaviour {

  [SerializeField]
  private BaseCollisionEmitter collisionEmitter;

  [SerializeField]
  private ExplosionDamage explosionDamage;

  [SerializeField]
  private CinemachineImpulseSource impulseSource;

  private readonly HashSet<Transform> hitTargets = new HashSet<Transform>();

  private void Awake() {
    collisionEmitter.OnCollision += HandleCollision;
  }

  private void Start() {
    impulseSource.GenerateImpulse();
  }

  private void HandleCollision(RaycastHit2D hit, CollisionType type) {
    switch (type) {
      case CollisionType.Character:
      case CollisionType.Projectile:
        OnTargetHit(hit.transform);
        break;
    }
  }

  private void OnTargetHit(Transform hit) {
    if (hitTargets.Contains(hit)) {
      return;
    }
    hitTargets.Add(hit);

    IDamagable collisionHandler = hit.GetComponent<IDamagable>();
    if (collisionHandler != null) {
      collisionHandler.TakeDamage(explosionDamage.GetDamage(), DamageType.Explosion);
    }
  }
}
