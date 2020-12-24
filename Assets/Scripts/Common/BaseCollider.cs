using UnityEngine;
using System;

public class BaseCollider : MonoBehaviour {

  private static readonly RaycastHit2D[] results = new RaycastHit2D[16];

  [SerializeField]
  private new Collider2D collider;

  public Action<RaycastHit2D> OnCollision { get; set; } = delegate { };

  public void ColliderDisable() {
    collider.enabled = false;
  }

  public void ColliderEnable() {
    collider.enabled = true;
  }

  private void FixedUpdate() {
    CheckCollisions();
  }

  private void CheckCollisions() {
    int count = collider.Cast(Vector2.zero, results);
    for (int i = 0; i < count; i++) {
      RaycastHit2D hit = results[i];
      OnCollision(hit);
    }
  }
}
