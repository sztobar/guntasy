using UnityEngine;

namespace Kite {
  public class CollisionMoveController : ICollisionMove {

    private readonly Transform transform;
    private readonly float skinWidth;

    public CollisionMoveController(Transform transform, float skinWidth = Constants.SKIN_WIDTH) {
      this.transform = transform;
      this.skinWidth = skinWidth;
    }

    public float GetAllowedMoveInto(RaycasterHit hit, float rayLength) {
      if (rayLength <= hit.DistanceToHit) {
        return rayLength;
      }
      ICollidable collidable = CollidableHelpers.GetCollidable(hit.Transform);

      //float collideDistance = Mathf.Max(0.0f, allowedMove - hit.DistanceToHit);
      float collideDistance = hit.GetCollideDistance(rayLength, skinWidth);
      float allowedCollideDistance = collidable.GetAllowedMoveInto(transform, collideDistance, hit.RayDirection, hit.Point);
      float allowedDistance = allowedCollideDistance + hit.DistanceToHit - skinWidth;

      return Mathf.Clamp(allowedDistance, 0, rayLength);
    }
  }
}