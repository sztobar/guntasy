using UnityEngine;
using Kite;

namespace Drone
{
    public class DronePhysicsComponent : OldPhysicsComponent
    {
        [SerializeField] private float cornerCorrectionAmount;

        public override Vector2 Move(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst)
        {
            if (wantsToMoveAmount.y > 0)
            {
                float cornerCorrectionMoveResult = GetCornerCorrectionMovement(wantsToMoveAmount.y);
                if (cornerCorrectionMoveResult != 0)
                {
                    float correctedWantsToMoveAmountX = wantsToMoveAmount.x + cornerCorrectionMoveResult;
                    if (correctedWantsToMoveAmountX > 0)
                    {
                        correctedWantsToMoveAmountX = Mathf.Floor(correctedWantsToMoveAmountX);
                    }
                    else
                    {
                        correctedWantsToMoveAmountX = Mathf.Ceil(correctedWantsToMoveAmountX);
                    }
                    wantsToMoveAmount.x = correctedWantsToMoveAmountX;
                    return base.Move(wantsToMoveAmount, mode);
                }
            }
            return base.Move(wantsToMoveAmount, mode);
        }

        private float GetCornerCorrectionMovement(float verticalMovementAmount)
        {
            for (int j = 1; j >= -1; j -= 2)
            {
                if (!HasColliderAbove(j, verticalMovementAmount))
                {
                    continue;
                }
                for (int i = 1; i < cornerCorrectionAmount + 1; i++)
                {
                    float horizontalMovementAmount = i * j;
                    if (!HasColliderAbove(horizontalMovementAmount, verticalMovementAmount))
                    {
                        return i * j;
                    }
                }
            }
            return 0;
        }

        private bool HasColliderAbove(float x, float y)
        {
            Bounds testBounds = collider.bounds;
            Vector2 origin;
            if (x > 0)
            {
                origin = new Vector2(testBounds.min.x + x, testBounds.max.y);
            }
            else
            {
                origin = new Vector2(testBounds.max.x + x, testBounds.max.y);
            }
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, y, collisionMask.value);

            //Debug.DrawRay(origin, Vector2.up * y, Color.red);
            return hit.collider != null;
        }
    }
}