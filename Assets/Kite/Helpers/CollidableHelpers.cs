using UnityEngine;
using System.Collections;
using System;

namespace Kite {
  public static class CollidableHelpers {

    public static ICollidable GetCollidable(Transform transform) {
      ICollidable collidable = transform.GetComponent<ICollidable>();
      return collidable ?? DefaultCollidable.Get();
    }

    public static float GetAllowedDistance(Transform transform, float distance, Direction4 direction, RaycastHit2D hit) {
      if (distance <= hit.distance) {
        return distance;
      }
      ICollidable collidable = GetCollidable(hit.transform);

      float collideDistance = Mathf.Max(0.0f, distance - hit.distance);
      float allowedCollideDistance = collidable.GetAllowedMoveInto(transform, collideDistance, direction, hit.point);
      float allowedDistance = allowedCollideDistance + hit.distance;// - skinWidth;

      return Mathf.Min(allowedDistance, distance);
    }

    public static void ForceMoveInto(Transform transform, float distance, Direction4 direction, RaycastHit2D raycastHit) {
      ICollidable collidable = GetCollidable(raycastHit.transform);
      float collideDistance = Mathf.Max(0.0f, distance - raycastHit.distance);
      collidable.ForceMoveInto(transform, collideDistance, direction);
    }
  }
}