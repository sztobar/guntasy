using UnityEngine;
using System.Collections.Generic;
using Kite;

public class PlayerWallSlideComponent : PlayerComponent {

  [SerializeField]
  [Tooltip("Transform object for wall slide check")]
  private Transform WallSlidePosition;

  [SerializeField]
  [Tooltip("Raycast length for wall slide check")]
  private float wallTouchDistance;

  [SerializeField]
  [Tooltip("Fall speed when wall sliding")]
  private float wallSlideMaxTileVelocity;

  [SerializeField]
  [Tooltip("Jump when player is clicking arrow in wall direction")]
  private Vector2 wallClimbTileVelocity;

  [SerializeField]
  [Tooltip("Jump when player is not clicking any arrow keys")]
  private Vector2 jumpOffTileVelocity;

  [SerializeField]
  [Tooltip("Jump when player is clicking arrow opposite to wall direction")]
  private Vector2 wallLeapTileVelocity;

  [SerializeField]
  [Tooltip("Time to leap after player is no longer clicking arrow key")]
  private float timeToWallUnstick;

  private float unstickTimeLeft;
  private readonly Dictionary<Direction2H, bool> wallTouchDict = new Dictionary<Direction2H, bool> { { Direction2H.Left, false }, { Direction2H.Right, false } };

  #region dependencies
  private PlayerGroundComponent ground;
  private PlayerPhysicsComponent physics;
  private PlayerInputHandler input;
  private PlayerJumpComponent jump;
  private PlayerAnimator animator;
  private PlayerPowerupHandler powerup;
  #endregion

  private bool isCurrentlyWallSliding;
  private float WallSlideMaxVelocity => TileHelpers.TileToWorld(wallSlideMaxTileVelocity);
  private Vector2 WallClimbVelocity => jump.JumpVelocity(wallClimbTileVelocity);
  private Vector2 JumpOffVelocity => jump.JumpVelocity(jumpOffTileVelocity);
  private Vector2 WallLeapVelocity => jump.JumpVelocity(wallLeapTileVelocity);

  public bool IsWallSliding => isCurrentlyWallSliding || unstickTimeLeft > 0;
  public bool CanWallJump => powerup.CanWallSlide && (wallTouchDict[Direction2H.Left] || wallTouchDict[Direction2H.Right]) && !ground.IsGrounded;
  public bool IsTouchingWall(Direction2H direction) => wallTouchDict[direction];

  public override void PlayerAwake(PlayerGameplayController controller) {
    ground = controller.Ground;
    jump = controller.Jump;
    physics = controller.DI.Physics;
    input = controller.DI.Input;
    animator = controller.DI.Animator;
    powerup = controller.DI.Powerup;
  }

  protected override void PlayerFixedUpdateImpl() {
    CheckWallTouch();

    float moveX = input.MoveInput;
    Direction2H moveDirection = moveX > 0 ? Direction2H.Right : Direction2H.Left;

    bool wasWallSliding = isCurrentlyWallSliding;

    if (CanWallSlide() && moveX != 0 && physics.Velocity.CurrentCollision[moveDirection] && wallTouchDict[moveDirection]) {
      isCurrentlyWallSliding = true;
      unstickTimeLeft = timeToWallUnstick;
      WallSlideVelocityUpdate(moveX, moveDirection);
      //animator.PlayWallSlide();
    } else {
      isCurrentlyWallSliding = false;
    }

    if (!wasWallSliding && isCurrentlyWallSliding) {
      Debug.Log("[WallSlide] Start");
    }
    if (wasWallSliding && !isCurrentlyWallSliding) {
      Debug.Log("[WallSlide] End");
    }

    if (isCurrentlyWallSliding || unstickTimeLeft > 0 || CanWallJump) {
      unstickTimeLeft -= Time.deltaTime;
      WallSlideInputUpdate(moveX, moveDirection);
    }
  }

  private bool CanWallSlide() {
    return powerup.CanWallSlide && !physics.IsGrounded && physics.Velocity.Y < 0;
  }

  private void CheckWallTouch() {
    Bounds bounds = physics.Movement.Bounds;
    Vector2 origin = WallSlidePosition.position;
    wallTouchDict[Direction2H.Left] = CastForWall(origin - new Vector2(bounds.extents.x, 0), Direction2H.Left);
    wallTouchDict[Direction2H.Right] = CastForWall(origin + new Vector2(bounds.extents.x, 0), Direction2H.Right);
  }

  private bool CastForWall(Vector2 position, Direction2H direction) {
    RaycastHit2D hit = Physics2D.Raycast(position, direction.ToVector2(), wallTouchDistance, Physics2D.GetLayerCollisionMask(gameObject.layer));
    Debug.DrawLine(position, position + direction.ToVector2(wallTouchDistance), Color.blue);
    return hit;
  }

  private void WallSlideVelocityUpdate(float moveX, Direction2H moveDirection) {
    if (physics.Velocity.Y < -WallSlideMaxVelocity) {
      physics.Velocity.Y = -WallSlideMaxVelocity;
    }
    physics.Velocity.X = 2 * Constants.SKIN_WIDTH * moveX;
  }

  private void WallSlideInputUpdate(float moveX, Direction2H moveDirection) {
    if (input.JumpButtonPressed) {
      Vector2 jumpVelocity;
      bool isBetweenWalls = wallTouchDict[Direction2H.Left] && wallTouchDict[Direction2H.Right];
      if (moveX == 0) {
        jumpVelocity = JumpOffVelocity;
        Debug.Log("[WallSlide] Jump Off");
      } else if (wallTouchDict[moveDirection] || isBetweenWalls) {
        jumpVelocity = WallClimbVelocity;
        Debug.Log("[WallSlide] Jump Climb");
      } else {
        jumpVelocity = WallLeapVelocity;
        Debug.Log("[WallSlide] Jump Leap");
      }
      float wallSlideJumpDirection = wallTouchDict[Direction2H.Left] ? 1 : -1;
      if (isBetweenWalls) {
        wallSlideJumpDirection = 0;
      }
      Vector2 oppositeToWallVector = new Vector2(wallSlideJumpDirection, 1);
      physics.Velocity.Value = jumpVelocity * oppositeToWallVector;
      unstickTimeLeft = 0;
      isCurrentlyWallSliding = false;
      input.JumpButtonCancel();
    }
  }

}
