using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Kite {

  [Serializable]
  public class EdgeRaycaster : IRaycaster {

    private readonly int layerCollisionMask;
    private readonly float skinWidth;

    private readonly int rayCount;
    private readonly Vector2[] rayDeltas;
    private readonly RaycastHit2D[] rayHits;

    private Bounds bounds;
    private readonly Vector2 positionOffset;
    private readonly Orientation orientation;

    private readonly RaycasterHitsFactory raycasterHitsFactory;

    public int RayCount => rayCount;
    public RaycastHit2D[] RayHits => rayHits;

    public EdgeRaycaster(Collider2D collider, Orientation orientation, int layerCollisionMask, float skinWidth = Constants.SKIN_WIDTH) {
      this.orientation = orientation;
      bounds = collider.bounds;
      positionOffset = collider.offset;
      this.layerCollisionMask = layerCollisionMask;
      this.skinWidth = skinWidth;

      int vectorIndex = orientation.ToVector2Index();
      float length = bounds.size[vectorIndex];
      float lengthWithMargin = length - 2 * Constants.RAYCAST_MARGIN;

      rayCount = Mathf.CeilToInt(lengthWithMargin / Constants.RAYCAST_GAP) + 1;
      rayDeltas = GenerateRayDeltas(rayCount, lengthWithMargin);
      rayHits = new RaycastHit2D[rayCount];
    }

    public IEnumerable<RaycasterHit> GetHits(Vector2 position, float distance, Direction4 direction) {
      if (direction.IsOrientation(orientation)) {
        Debug.LogWarning($"EdgeRaycaster Orientation.{orientation} got called GetRaycastHits with Direction4.{direction}");
        return Array.Empty<RaycasterHit>();
      }
      return GetEdgeHits(position, direction.ToVector2(distance), direction);
    }

    public IEnumerable<RaycasterHit> GetHits(Vector2 position, Vector2 ray) {
      int perpendicularVectorIndex = orientation.Opposite().ToVector2Index();
      float perpendicularRayLength = ray[perpendicularVectorIndex];
      if (perpendicularRayLength == 0) {
        Debug.LogWarning($"EdgeRaycaster Orientation.{orientation} got called GetRaycastHits with Vector2={position}. Only perpendicular vectors are allowed.");
        return Array.Empty<RaycasterHit>();
      }
      Direction4 direction = ray.ToDirection4InAxis(perpendicularVectorIndex);
      return GetEdgeHits(position, direction.ToVector2(perpendicularRayLength), direction);
    }

    //public RaycastHit2D[] GetRaycastHits(Vector2 position, float distance, Direction4 direction, LayerMask collisionMask, float skinWidth = 0f) {
    //  if (direction.IsOrientation(orientation)) {
    //    Debug.LogWarning($"EdgeRaycaster Orientation.{orientation} got called GetRaycastHits with Direction4.{direction}");
    //    return Array.Empty<RaycastHit2D>();
    //  }
    //  return GetEdgeHits(position, direction.ToVector2(distance), direction, collisionMask, skinWidth);
    //}

    //public RaycastHit2D[] GetRaycastHits(Vector2 position, Vector2 ray, LayerMask collisionMask, float skinWidth = 0f) {
    //  int perpendicularVectorIndex = orientation.Opposite().ToVector2Index();
    //  float perpendicularLength = ray[perpendicularVectorIndex];
    //  if (perpendicularLength != 0) {
    //    Direction4 direction = ray.ToDirection4InAxis(perpendicularVectorIndex);
    //    return GetEdgeHits(position, direction.ToVector2(perpendicularLength), direction, collisionMask, skinWidth);
    //  }
    //  Debug.LogWarning($"EdgeRaycaster Orientation.{orientation} got called GetRaycastHits with Vector2={position}");
    //  return Array.Empty<RaycastHit2D>();
    //}

    private IEnumerable<RaycasterHit> GetEdgeHits(Vector2 position, Vector2 ray, Direction4 side) {
      RaycastHit2D[] raycastHits = GetRaycastHits2D(position, ray, side);
      return raycasterHitsFactory.GetUniqueRaycasterHits(raycastHits);
    }

    private RaycastHit2D[] GetRaycastHits2D(Vector2 position, Vector2 ray, Direction4 side) {
      bounds.center = position + positionOffset;
      float rayLength = ray.magnitude;
      Vector2 rayDirection = ray.normalized;
      Vector2 boundsRayOrigin = GetBoundsRayOrigin(side, skinWidth);

      for (int i = 0; i < rayCount; i++) {
        Vector2 rayOrigin = boundsRayOrigin + rayDeltas[i];
        rayHits[i] = Physics2D.Raycast(rayOrigin, rayDirection, rayLength, layerCollisionMask);

        Debug.DrawRay(rayOrigin, ray, Color.red);
      }
      return rayHits;
    }

    private Vector2 GetBoundsRayOrigin(Direction4 side, float skinWidth) {
      switch (side) {
        case Direction4.Up:
          return new Vector2(bounds.min.x + Constants.RAYCAST_MARGIN, bounds.max.y - skinWidth);
        case Direction4.Down:
          return new Vector2(bounds.min.x + Constants.RAYCAST_MARGIN, bounds.min.y + skinWidth);
        case Direction4.Right:
          return new Vector2(bounds.max.x - skinWidth, bounds.min.y + Constants.RAYCAST_MARGIN);
        case Direction4.Left:
          return new Vector2(bounds.min.x + skinWidth, bounds.min.y + Constants.RAYCAST_MARGIN);
        default:
          throw new ArgumentException($"Unknown Direction4 passed: {side}");
      }
    }

    private Vector2[] GenerateRayDeltas(int rayCount, float maxDelta) {
      Vector2 deltaVector = orientation == Orientation.Horizontal ? Vector2.right : Vector2.up;
      Vector2[] rayDeltas = new Vector2[rayCount];
      int lastDeltaIndex = rayCount - 1;
      for (int i = 0; i < lastDeltaIndex; i++) {
        rayDeltas[i] = deltaVector * Constants.RAYCAST_GAP * i;
      }
      rayDeltas[lastDeltaIndex] = deltaVector * Mathf.Min(Constants.RAYCAST_GAP * lastDeltaIndex, maxDelta);
      return rayDeltas;
    }
  }
}