using UnityEngine;
using Kite;

public class PlayerDodgeComponent : PlayerComponent {

  [SerializeField]
  private float dodgeTileVelocity;

  [SerializeField]
  [Tooltip("Minimal time between dodges")]
  private float dodgeDelay;

  [SerializeField]
  private bool rollOnlyWhenGrounded;

  private float dodgeDelayLeft;
  private bool leapInProgress;
  private bool rollInProgress;

  private PlayerAnimator animator;
  private PlayerInputHandler input;
  private PlayerJumpComponent jump;
  private PlayerGroundComponent ground;
  private PlayerDashComponent dash;
  private PlayerPhysicsComponent physics;
  private HorizontalFlipComponent playerFlip;
  private Direction2H dodgeDirection;

  public bool IsDodging() {
    return leapInProgress || rollInProgress;
  }

  private bool CanDodge() {
    return !IsDodging() && dodgeDelayLeft <= 0 && !dash.IsDashing;
  }

  public override void PlayerAwake(PlayerGameplayController controller) {
    animator = controller.DI.Animator;
    input = controller.DI.Input;
    jump = controller.Jump;
    ground = controller.Ground;
    dash = controller.Dash;
    physics = controller.DI.Physics;
    playerFlip = controller.DI.Flip;
  }

  protected override void PlayerFixedUpdateImpl() {
    if (leapInProgress) {
      LeapUpdate();
    } else if (rollInProgress) {
      RollUpdate();
    } else if (input.DodgeButtonPressed && CanDodge()) {
      input.DodgeButtonCancel();
      PerformDodgeLeap();
    } else if (dodgeDelayLeft > 0) {
      dodgeDelayLeft -= Time.deltaTime;
    }
  }

  public void OnDodgeLeapAnimationEnded() {
    leapInProgress = false;
    if (!rollOnlyWhenGrounded || ground.IsGrounded) {
      PerformDodgeRoll();
    } else {
      OnDodgeEnd();
    }
  }

  public void OnDodgeRollAnimationEnded() {
    rollInProgress = false;
    OnDodgeEnd();
  }

  private void OnDodgeEnd() {
    dodgeDelayLeft = dodgeDelay;
    jump.PlayerEnable();
    dash.PlayerEnable();
  }

  private void RollUpdate() {
    animator.PlayDodgeRoll();
    SetDodgeVelocity();
  }

  private void LeapUpdate() {
    animator.PlayDodgeLeap();
    SetDodgeVelocity();
  }

  private void SetDodgeVelocity() {
    physics.Velocity.X = dodgeTileVelocity * TileHelpers.TILE_SIZE * dodgeDirection.ToFloat();
  }

  private void PerformDodgeLeap() {
    leapInProgress = true;

    animator.StartDodgeLeap();
    dodgeDirection = input.InputDirection;
    playerFlip.Direction = dodgeDirection;
    jump.PlayerDisable();
    dash.PlayerDisable();
  }

  private void PerformDodgeRoll() {
    rollInProgress = true;
    animator.StartDodgeRoll();
  }
}
