using UnityEngine;
using System.Collections;

namespace Kite {
  public static class PlatformCollidableHelpers {

    private static readonly float BOX_TOP_TOLERANCE = 0.1f;

    public static float GetGridAllowedMovementInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) {
      if (direction == Direction4.Down && !CanSkipPlatform(wantsToMove)) {
        //BoxCollider2D wantsToMoveBoxCollider = wantsToMove.GetComponent<BoxCollider2D>();
        //float collisionY = wantsToMoveBoxCollider.bounds.min.y - collideDistance;
        //float roundedPointY = (float)Mathf.Round(hit.point.y * 100f) / 100f;
        float roundedPointY = (float)Mathf.Round(hitPoint.y * 100f) / 100f;
        if (roundedPointY % 16f == 0) {
          return 0;
        }
      }
      return collideDistance;
    }

    public static float GetBoxColliderAllowedMovementInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint, BoxCollider2D boxCollider) {
      if (direction == Direction4.Down && CollidesWithBoxTop(hitPoint, boxCollider) && !CanSkipPlatform(wantsToMove)) {
        return 0;
      }
      return collideDistance;
    }

    public static float GetEdgeColliderAllowedMovementInto(Transform wantsToMove, float collideDistance, Direction4 direction) {
      if (direction == Direction4.Down && !CanSkipPlatform(wantsToMove)) {
        return 0;
      }
      return collideDistance;
    }

    private static bool CollidesWithBoxTop(Vector2 hitPoint, BoxCollider2D boxCollider) {
      return boxCollider.bounds.max.y - hitPoint.y < BOX_TOP_TOLERANCE;
      //return Mathf.Approximately(hit.point.y, boxCollider.bounds.max.y);
    }

    private static bool CanSkipPlatform(Transform transform) {
      PlatformSkipabble skipabble = transform.GetComponent<PlatformSkipabble>();
      return skipabble && skipabble.CanSkip;
    }
  }
}