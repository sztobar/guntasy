using UnityEngine;
using System.Collections;

public class ColliderCollisionEmitter : BaseCollisionEmitter {

  private static readonly RaycastHit2D[] results = new RaycastHit2D[16];

  [SerializeField]
  private new Collider2D collider;

  public override void Cast() {
    int count = collider.Cast(Vector2.zero, results);
    for (int i = 0; i < count; i++) {
      RaycastHit2D hit = results[i];
      HandleCollision(hit);
    }
  }
}
