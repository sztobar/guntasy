using UnityEngine;
using System.Collections.Generic;

namespace Kite {
  public class RaycasterHitResolver {

    private readonly Transform transform;
    private readonly int layerCollisionMask;
    private readonly BoxRaycaster raycaster;
    //private readonly RaycasterHitsFactory uniqueRayHits;

    public RaycasterHitResolver(Transform transform, BoxCollider2D boxCollider, int layerCollisionMask) {
      this.transform = transform;
      this.layerCollisionMask = layerCollisionMask;
      raycaster = new BoxRaycaster(boxCollider, layerCollisionMask);
      //uniqueRayHits = new RaycasterHitsFactory();
    }

    public float ResolveAllowedDistance(float distance, Direction4 direction, Vector2 position) {
      float skinWidth = Constants.SKIN_WIDTH;
      float rayLength = distance + skinWidth;
      List<RaycastHit2D> raycastHitsForMovement = RaycastHitsForMovement(rayLength, direction, position, skinWidth);

      float allowedDistance = rayLength;
      foreach (RaycastHit2D raycastHit in raycastHitsForMovement) {
        allowedDistance = CollidableHelpers.GetAllowedDistance(transform, allowedDistance, direction, raycastHit);
      }
      float finalDistance = Mathf.Clamp(allowedDistance, 0, distance);
      return finalDistance;
    }

    public void ResolveForceDistance(float distance, Direction4 direction, Vector2 position) {
      List<RaycastHit2D> raycastHitsForMovement = RaycastHitsForMovement(distance, direction, position, Constants.SKIN_WIDTH);
      foreach (RaycastHit2D raycastHit in raycastHitsForMovement) {
        CollidableHelpers.ForceMoveInto(transform, distance, direction, raycastHit);
      }
    }

    public List<RaycastHit2D> RaycastHitsForMovement(float distance, Direction4 direction, Vector2 position, float skinWidth) {
      return new List<RaycastHit2D>();
      //RaycastHit2D[] hits = raycaster.GetRaycastHits(position, distance, direction, layerCollisionMask, skinWidth);
      //return uniqueRayHits.GetUnique(hits);
    }
  }
}