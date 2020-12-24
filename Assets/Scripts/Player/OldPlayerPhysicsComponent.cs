using Kite;
using System;
using UnityEngine;

// TODO: composition instead of inheritance
public class OldPlayerPhysicsComponent : OldPhysicsComponent {

  private static readonly float raycastMargin = 0.1f;
  private static readonly float minCorrection = 0.01f;

  [SerializeField] private float jumpCornerCorrectionAmount = 5;
  [SerializeField] private float moveCornerCorrectionAmount = 8;

  public void PlayerFixedUpdate() {

  }

  public override Vector2 Move(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst) {
    if (wantsToMoveAmount.y > 0) {
      float cornerCorrectionMoveResult = GetJumpCornerCorrectionMovement(wantsToMoveAmount.y);
      if (cornerCorrectionMoveResult > minCorrection) {
        Debug.Log($"[PlayerPhysicsComponent] jump correction: {cornerCorrectionMoveResult}");
        wantsToMoveAmount.x += cornerCorrectionMoveResult;
      }
    } else if (wantsToMoveAmount.y == 0 && wantsToMoveAmount.x != 0) {
      float cornerCorrectionMoveResult = GetMoveCornerCorrectionMovement(wantsToMoveAmount.x);
      if (cornerCorrectionMoveResult > minCorrection) {
        Debug.Log($"[PlayerPhysicsComponent] move correction: {cornerCorrectionMoveResult}");
        wantsToMoveAmount.y -= cornerCorrectionMoveResult;

        return base.Move(wantsToMoveAmount, MoveMode.VerticalFirst);
      }
    }
    return base.Move(wantsToMoveAmount);
  }

  private float GetJumpCornerCorrectionMovement(float topMovementAmount) {
    Bounds testBounds = collider.bounds;
    float rayLength = jumpCornerCorrectionAmount + raycastMargin;
    //float leftRayLength = jumpCornerCorrectionAmount + raycastMargin;
    Vector2 leftRayOrigin = new Vector2(testBounds.min.x + rayLength, testBounds.max.y + topMovementAmount);
    RaycastHit2D leftRayHit = Physics2D.Raycast(leftRayOrigin, Vector2.left, rayLength - raycastMargin, collisionMask.value);
    if (leftRayHit.distance > raycastMargin && !CanMoveInto(leftRayHit, topMovementAmount, Direction4.Up)) {
      return rayLength - leftRayHit.distance;
    }
    //float rightRayLength = jumpCornerCorrectionAmount + raycastMargin;
    Vector2 rightRayOrigin = new Vector2(testBounds.max.x - rayLength, testBounds.max.y + topMovementAmount);
    RaycastHit2D rightRayHit = Physics2D.Raycast(rightRayOrigin, Vector2.right, rayLength - raycastMargin, collisionMask.value);
    //if (HasSolidCollider(rightRayHit) && rightRayHit.distance > raycastMargin) {
    //  return -(rightRayLength - rightRayHit.distance);
    //}
    if (rightRayHit.distance > raycastMargin && !CanMoveInto(leftRayHit, topMovementAmount, Direction4.Up)) {
      return -(rayLength - rightRayHit.distance);
    }
    return 0;
  }

  private float GetMoveCornerCorrectionMovement(float horizontalMovementAmount) {
    Bounds testBounds = collider.bounds;
    {
      float upRayLength = moveCornerCorrectionAmount + raycastMargin;
      float xSign = Mathf.Sign(horizontalMovementAmount);
      float yRaySign = 1;
      Vector2 upRayOrigin = new Vector2(
        testBounds.center.x + (xSign * testBounds.extents.x) + horizontalMovementAmount,
        testBounds.center.y + (yRaySign * testBounds.extents.y) - upRayLength
      );
      RaycastHit2D upRayHit = Physics2D.Raycast(upRayOrigin, Vector2.up * yRaySign, upRayLength, collisionMask.value);
      Debug.DrawRay(upRayOrigin + (Vector2.right * 5 * xSign), Vector2.up * yRaySign * upRayLength);
      if (HasSolidCollider(upRayHit) && upRayHit.distance > raycastMargin) {
        return upRayLength - upRayHit.distance;
      }
    }
    {
      float downRay = -(moveCornerCorrectionAmount + raycastMargin);
      float downRayLength = Mathf.Abs(downRay);
      float xSign = Mathf.Sign(horizontalMovementAmount);
      float yRaySign = Mathf.Sign(downRay);
      Vector2 downRayOrigin = new Vector2(
        testBounds.center.x + (xSign * testBounds.extents.x) + horizontalMovementAmount,
        testBounds.center.y + (yRaySign * testBounds.extents.y) - downRay
      );
      RaycastHit2D downRayHit = Physics2D.Raycast(downRayOrigin, Vector2.up * yRaySign, downRayLength, collisionMask.value);
      Debug.DrawRay(downRayOrigin + (Vector2.right * 5 * xSign), Vector2.up * yRaySign * downRayLength);
      if (HasCollider(downRayHit) && downRayHit.distance > raycastMargin) {
        return yRaySign * (downRayLength - downRayHit.distance);
      }
    }
    return 0;
  }

  private bool CanMoveInto(RaycastHit2D hit, float distance, Direction4 direction) {
    if (hit.collider) {
      ICollidable collidable = hit.collider.GetComponent<ICollidable>();
      if (collidable == null) {
        collidable = DefaultCollidable.Get();
      }
      float allowedMove = collidable.GetAllowedMoveInto(transform, distance, direction, hit.point);
      return allowedMove == distance;
    }
    return true;
  }

  private bool HasSolidCollider(RaycastHit2D hit) {
    if (HasCollider(hit)) {
      ICollidable collidable = hit.collider.GetComponent<ICollidable>();
      if (collidable == null) {
        return true;
      }
      return collidable == null;// || collidable.IsPlatform == false;
    }
    return false;
  }

  private bool HasCollider(RaycastHit2D hit) {
    return hit.collider;
  }
}
