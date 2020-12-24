using UnityEngine;
using Kite;

public class PlayerPhysicsComponent : MonoBehaviour {

  [SerializeField] private PhysicsVelocity velocity;
  [SerializeField] private PhysicsGravity gravity;
  [SerializeField] private PhysicsMovement movement;
  [SerializeField] private CornerCorrectionMovement cornerCorrection;

  public PhysicsVelocity Velocity => velocity;
  public PhysicsMovement Movement => movement;
  public PhysicsGravity Gravity => gravity;

  public bool IsGrounded => velocity.CurrentCollision[Direction4.Down];

  public void PlayerFixedUpdate() {
    Vector2 deltaPosition = velocity.deltaPosition;
    Vector2 cornerCorrectionMove = cornerCorrection.GetCornerMoveCorrection(deltaPosition);
    movement.TryToMove(cornerCorrectionMove);
    Vector2 moveAmount = movement.TryToMove(deltaPosition);
    velocity.ResolveCollision(moveAmount);
  }
}
