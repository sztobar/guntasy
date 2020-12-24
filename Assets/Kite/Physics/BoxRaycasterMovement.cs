using UnityEngine;
using System.Collections.Generic;

namespace Kite {
  public class BoxRaycasterMovement : PhysicsMovement {

    [SerializeField] protected new Rigidbody2D rigidbody;
    [SerializeField] protected BoxCollider2D boxCollider;

    private RaycasterHitResolver raycasterHitResolver;

    public override Bounds Bounds => boxCollider.bounds;
    public Vector2 Position => rigidbody.position;

    public override Vector2 GetAllowedMovement(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst) {
      Vector2 movedAmount = Vector2.zero;
      foreach (int vectorIndex in mode.GetVectorIndexes()) {
        float distance = Mathf.Abs(wantsToMoveAmount[vectorIndex]);
        Direction4 direction = wantsToMoveAmount.ToDirection4InAxis(vectorIndex);
        float sign = Mathf.Sign(wantsToMoveAmount[vectorIndex]);
        Vector2 origin = rigidbody.position + movedAmount;
        movedAmount[vectorIndex] = sign * ResolveAllowedMovement(distance, direction, origin);
      }
      return movedAmount;
    }

    public override float GetAllowedMovement(float distance, Direction4 direction) {
      return ResolveAllowedMovement(distance, direction, rigidbody.position);
    }

    public override void ForceMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst) {
      foreach (int vectorIndex in mode.GetVectorIndexes()) {
        float distance = Mathf.Abs(wantsToMoveAmount[vectorIndex]);
        if (distance == 0) {
          continue;
        }
        Direction4 direction = wantsToMoveAmount.ToDirection4InAxis(vectorIndex);
        ForceMove(distance, direction);
      }
    }

    public override void ForceMove(float distance, Direction4 direction) {
      Vector2 position = rigidbody.position;
      raycasterHitResolver.ResolveForceDistance(distance, direction, position);
      rigidbody.position = position + direction.ToVector2(distance);
    }

    public override Vector2 TryToMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst) {
      Vector2 movedAmount = Vector2.zero;
      foreach (int vectorIndex in mode.GetVectorIndexes()) {
        float distance = Mathf.Abs(wantsToMoveAmount[vectorIndex]);
        if (distance == 0) {
          continue;
        }
        Direction4 direction = wantsToMoveAmount.ToDirection4InAxis(vectorIndex);
        float sign = Mathf.Sign(wantsToMoveAmount[vectorIndex]);
        movedAmount[vectorIndex] = sign * TryToMove(distance, direction);
      }
      return movedAmount;
    }

    public override float TryToMove(float distance, Direction4 direction) {
      float allowedMove = GetAllowedMovement(distance, direction);
      ForceMove(allowedMove, direction);
      return allowedMove;
    }

    private float ResolveAllowedMovement(float distance, Direction4 direction, Vector2 origin) {
      if (distance == 0) {
        return distance;
      }
      return raycasterHitResolver.ResolveAllowedDistance(distance, direction, origin);
    }

    void Awake() {
      raycasterHitResolver = new RaycasterHitResolver(transform, boxCollider, Physics2D.GetLayerCollisionMask(gameObject.layer));
    }
  }
}