using UnityEngine;
using System.Collections;
using Common;
using System;
using Interactive;

namespace Enemies.Components {
  public class EnemyTargetDetectorComponent : BaseEnemyComponent {

    private static readonly RaycastHit2D[] results = new RaycastHit2D[1];

    [SerializeField]
    private Collider2D colliderWithoutTarget;

    [SerializeField]
    private Collider2D colliderWithTarget;

    private Transform currentTarget;

    public bool HasTarget() => currentTarget;
    public Vector2 TargetPosition => currentTarget ? currentTarget.transform.position : Vector3.zero;

    public override void EnemyFixedAwake() {}
    public override void EnemyFixedUpdate() {}

    public void FixedUpdate() {
      CheckCollisions();
    }

    private void CheckCollisions() {
      Collider2D checkCollider = colliderWithoutTarget;
      if (HasTarget()) {
        checkCollider = colliderWithTarget;
      }
      int count = checkCollider.Cast(Vector2.zero, results);
      if (count > 0) {
        currentTarget = results[0].transform;
      } else {
        currentTarget = null;
      }
    }
  }
}