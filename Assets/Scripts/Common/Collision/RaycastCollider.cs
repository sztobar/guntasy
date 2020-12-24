using UnityEngine;
using System;
using Kite;

public class RaycastCollider {

  private static readonly RaycastHit2D[] results = new RaycastHit2D[32];

  private float rayLength;
  private RaycastHit2D[] rayHits;

  public RaycastHit2D[] Hits => rayHits;
  public float RayLength => rayLength;

  public void Cast(Vector2 origin, Vector2 direction, int layer) {
    Debug.DrawRay(origin, direction * 50f, Color.red, 1f);
    Bounds cameraBounds = Camera.main.GetBounds();
    float cameraDiagonal = Mathf.Sqrt(Mathf.Pow(cameraBounds.size.x, 2) + Mathf.Pow(cameraBounds.size.y, 2));
    int collisionMask = Physics2D.GetLayerCollisionMask(layer);

    int count = Physics2D.RaycastNonAlloc(origin, direction, results, cameraDiagonal, collisionMask);
    rayLength = cameraDiagonal;
    int i = 0;
    for (; i < count; i++) {
      RaycastHit2D hit = results[i];
      if (IsCollisionLayer(hit) || IsOutOfCamera(hit, ref cameraBounds)) {
        rayLength = (hit.point - origin).magnitude;
        break;
      }
    }
    if (i > 0) {
      rayHits = new RaycastHit2D[i];
      Array.Copy(results, rayHits, i);
    } else {
      rayHits = new RaycastHit2D[0];
    }
  }

  private bool IsCollisionLayer(RaycastHit2D hit) {
    return hit.transform.gameObject.layer == UnityConstants.Layers.Collision;
  }

  private bool IsOutOfCamera(RaycastHit2D hit, ref Bounds cameraBounds) {
    return !cameraBounds.Contains(hit.point);
  }
}
