using UnityEngine;
using System.Collections;

namespace Kite {
  public class CornerCorrectionMovement : MonoBehaviour {

    private static readonly float SKIN_WIDTH = Constants.SKIN_WIDTH;
    private static readonly float MIN_CORRECTION = SKIN_WIDTH;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float jumpCornerCorrectionAmount = 5;
    [SerializeField] private float moveCornerCorrectionAmount = 8;

    public int LayerMask => Physics2D.GetLayerCollisionMask(gameObject.layer);

    public Vector2 GetCornerMoveCorrection(Vector2 wantsToMoveAmount) {
      if (wantsToMoveAmount.y > 0) {
        float cornerCorrectionMoveResult = GetJumpCornerCorrectionMovement(wantsToMoveAmount.y);
        if (Mathf.Abs(cornerCorrectionMoveResult) > MIN_CORRECTION) {
          Debug.Log($"[CornerCorrectionMovement]: Jump Correction: {cornerCorrectionMoveResult}");
          return new Vector2(cornerCorrectionMoveResult, 0);
        }
      } else if (wantsToMoveAmount.y == 0 && wantsToMoveAmount.x != 0) {
        float cornerCorrectionMoveResult = GetMoveCornerCorrectionMovement(wantsToMoveAmount.x);
        if (Mathf.Abs(cornerCorrectionMoveResult) > MIN_CORRECTION) {
          Debug.Log($"[CornerCorrectionMovement]: Move Correction: {cornerCorrectionMoveResult}");
          return new Vector2(0, cornerCorrectionMoveResult);
        }
      }
      return Vector2.zero;
    }

    private float GetJumpCornerCorrectionMovement(float topMovementAmount) {
      Bounds testBounds = boxCollider.bounds;
      float rayLength = jumpCornerCorrectionAmount + SKIN_WIDTH;
      Vector2 leftRayOrigin = new Vector2(testBounds.min.x + rayLength, testBounds.max.y + topMovementAmount);
      RaycastHit2D leftRayHit = Physics2D.Raycast(leftRayOrigin, Vector2.left, rayLength, LayerMask);
      if (IsCorrectDistance(leftRayHit.distance, jumpCornerCorrectionAmount) && !CanMoveInto(leftRayHit, rayLength, Direction4.Left)) {
        return rayLength - leftRayHit.distance;
      }
      Vector2 rightRayOrigin = new Vector2(testBounds.max.x - rayLength, testBounds.max.y + topMovementAmount);
      RaycastHit2D rightRayHit = Physics2D.Raycast(rightRayOrigin, Vector2.right, rayLength, LayerMask);
      if (IsCorrectDistance(rightRayHit.distance, jumpCornerCorrectionAmount) && !CanMoveInto(rightRayHit, rayLength, Direction4.Right)) {
        return -(rayLength - rightRayHit.distance);
      }
      return 0;
    }

    private float GetMoveCornerCorrectionMovement(float horizontalMovementAmount) {
      Bounds testBounds = boxCollider.bounds;
      float xSign = Mathf.Sign(horizontalMovementAmount);
      float rayLength = moveCornerCorrectionAmount + SKIN_WIDTH;
      {
        Vector2 upRayOrigin = new Vector2(
          testBounds.center.x + xSign * testBounds.extents.x + horizontalMovementAmount,
          testBounds.center.y + testBounds.extents.y - rayLength
        );
        RaycastHit2D upRayHit = Physics2D.Raycast(upRayOrigin, Vector2.up, rayLength, LayerMask);
        Debug.DrawRay(upRayOrigin + Vector2.right * 5 * xSign, Vector2.up * rayLength);
        if (IsCorrectDistance(upRayHit.distance, moveCornerCorrectionAmount) && !CanMoveInto(upRayHit, rayLength, Direction4.Up)) {
          return -(rayLength - upRayHit.distance);
        }
      }
      {
        Vector2 downRayOrigin = new Vector2(
          testBounds.center.x + xSign * testBounds.extents.x + horizontalMovementAmount,
          testBounds.center.y + -testBounds.extents.y + rayLength
        );
        RaycastHit2D downRayHit = Physics2D.Raycast(downRayOrigin, Vector2.down, rayLength, LayerMask);
        Debug.DrawRay(downRayOrigin + Vector2.right * 5 * xSign, Vector2.down * rayLength);
        if (IsCorrectDistance(downRayHit.distance, moveCornerCorrectionAmount) && !CanMoveInto(downRayHit, rayLength, Direction4.Down)) {
          return rayLength - downRayHit.distance;
        }
      }
      return 0;
    }

    private bool IsCorrectDistance(float distance, float max) {
      return distance > 0 && distance < max;
    }

    private bool CanMoveInto(RaycastHit2D hit, float distance, Direction4 direction) {
      if (hit.collider) {
        ICollidable collidable = CollidableHelpers.GetCollidable(hit.transform);
        float collideDistance = distance - hit.distance;
        float allowedMove = collidable.GetAllowedMoveInto(transform, collideDistance, direction, hit.point);
        return allowedMove == collideDistance;
      }
      return true;
    }

  }
}