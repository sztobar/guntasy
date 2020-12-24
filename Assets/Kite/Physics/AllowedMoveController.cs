using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kite {
  public class AllowedMoveController : IAllowedMove {

    private IRaycaster raycaster;
    private ICollisionMove collisionMove;

    public AllowedMoveController(IRaycaster raycaster, ICollisionMove collisionMove) {
      this.raycaster = raycaster;
      this.collisionMove = collisionMove;
    }

    public Vector2 GetAllowedMovement(Vector2 position, Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst) {
      Vector2 movedAmount = Vector2.zero;
      foreach (int vectorIndex in mode.GetVectorIndexes()) {
        float distance = Mathf.Abs(wantsToMoveAmount[vectorIndex]);
        Direction4 direction = wantsToMoveAmount.ToDirection4InAxis(vectorIndex);
        float sign = Mathf.Sign(wantsToMoveAmount[vectorIndex]);
        Vector2 origin = position + movedAmount;
        movedAmount[vectorIndex] = sign * GetAllowedMovement(origin, distance, direction);
      }
      return movedAmount;
    }

    public float GetAllowedMovement(Vector2 position, float distance, Direction4 direction) {
      IEnumerable<RaycasterHit> raycasterHits = raycaster.GetHits(position, distance, direction);

      float allowedDistance = distance;
      foreach (RaycasterHit raycasterHit in raycasterHits) {
        allowedDistance = collisionMove.GetAllowedMoveInto(raycasterHit, allowedDistance);
      }
      return allowedDistance;
    }
  }
}