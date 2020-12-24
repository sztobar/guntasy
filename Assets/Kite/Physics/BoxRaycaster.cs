using UnityEngine;
using System;
using System.Collections.Generic;

namespace Kite {

  [Serializable]
  public class BoxRaycaster: IRaycaster {

    private readonly EdgeRaycaster horizontalEdgeRaycaster;
    private readonly EdgeRaycaster verticalEdgeRaycaster;
    //private RaycastHit2D[] diagonalRayHits;

    public BoxRaycaster(Collider2D collider, int layerCollisionMask, float skinWidth = Constants.SKIN_WIDTH) {
      horizontalEdgeRaycaster = new EdgeRaycaster(collider, Orientation.Horizontal, layerCollisionMask, skinWidth);
      verticalEdgeRaycaster = new EdgeRaycaster(collider, Orientation.Vertical, layerCollisionMask, skinWidth);
    }

    public IEnumerable<RaycasterHit> GetHits(Vector2 position, float distance, Direction4 direction) {
      if (direction.IsVertical()) {
        return horizontalEdgeRaycaster.GetHits(position, distance, direction);
      } else {
        return verticalEdgeRaycaster.GetHits(position, distance, direction);
      }
    }

    public IEnumerable<RaycasterHit> GetHits(Vector2 position, Vector2 ray) {
      if (ray.x == 0) {
        return horizontalEdgeRaycaster.GetHits(position, ray.y, ray.ToDirection4Vertical());
      } else if (ray.y == 0) {
        return verticalEdgeRaycaster.GetHits(position, ray.x, ray.ToDirection4Horizontal());
      }
      return GetDiagonalHits(position, ray);
    }

    private IEnumerable<RaycasterHit> GetDiagonalHits(Vector2 position, Vector2 ray) {
      Direction4 verticalSide = ray.ToDirection4InAxis(1);
      IEnumerable<RaycasterHit> horizontalRaycasterHits = horizontalEdgeRaycaster.GetHits(position, ray.y, verticalSide);
      foreach (RaycasterHit horizontalRaycasterHit in horizontalRaycasterHits) {
        yield return horizontalRaycasterHit;
      }
      Direction4 horizontalSide = ray.ToDirection4InAxis(0);
      IEnumerable<RaycasterHit> verticalRaycasterHits = verticalEdgeRaycaster.GetHits(position, ray.y, horizontalSide);
      foreach (RaycasterHit verticalRaycasterHit in verticalRaycasterHits) {
        yield return verticalRaycasterHit;
      }
      //if (diagonalRayHits == null) {
      //  diagonalRayHits = new RaycastHit2D[horizontalEdgeRaycaster.RayCount + verticalEdgeRaycaster.RayCount];
      //}

      //Direction4 verticalSide = ray.ToDirection4InAxis(1);
      //RaycastHit2D[] horizontalHits = horizontalEdgeRaycaster.GetRaycastHits(position, ray.y, verticalSide, collisionMask, skinWidth);
      //horizontalHits.CopyTo(diagonalRayHits, 0);

      //Direction4 horizontalSide = ray.ToDirection4InAxis(0);
      //RaycastHit2D[] verticalHits = verticalEdgeRaycaster.GetRaycastHits(position, ray.x, horizontalSide, collisionMask, skinWidth);
      //verticalHits.CopyTo(diagonalRayHits, horizontalHits.Length);

      //return diagonalRayHits;
    }
  }
}