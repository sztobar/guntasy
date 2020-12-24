using Kite;
using UnityEngine;

public class PlayerDashComponent : PlayerComponent {

  [SerializeField]
  private float dashDuration;

  [SerializeField]
  private float dashTileVelocity;

  [SerializeField]
  [Tooltip("Minimal time between ground dashes")]
  private float dashDelay;

  [SerializeField]
  [Tooltip("Time to stop dash aftery hitting a wall")]
  private float stopDashInWallTime;

  [SerializeField]
  [Tooltip("Duration of frozen movement after interrupting dash")]
  private float interruptedDashFreezeTime = 0.5f;

  #region Dependencies
  private PlayerInputHandler input;
  private PlayerWalkComponent walk;
  private PlayerJumpComponent jump;
  private PlayerGroundComponent ground;
  private HorizontalFlipComponent playerFlip;
  private PlayerPhysicsComponent physics;
  private PlayerAnimator animator;
  private PlayerPowerupHandler powerup;
  private PlayerSoundHandler sound;
  #endregion

  private bool haveDashed;
  private bool dashInProgress;
  private float timeLeftElapsed;
  private Direction2H dashDirection;
  private float gravityBackup;
  private float velocityXBackup;
  private bool isBackwardDash;
  private float hitWallTime;

  public bool IsDashing => dashInProgress;

  public override void PlayerAwake(PlayerGameplayController controller) {
    walk = controller.Walk;
    jump = controller.Jump;
    ground = controller.Ground;
    input = controller.DI.Input;
    playerFlip = controller.DI.Flip;
    physics = controller.DI.Physics;
    animator = controller.DI.Animator;
    powerup = controller.DI.Powerup;
    sound = controller.DI.Sound;
  }

  protected override void PlayerFixedUpdateImpl() {
    if (input.DashButtonPressed && CanDash()) {
      input.DashButtonCancel();
      OnDashStart();
    }
    if (dashInProgress) {
      DashUpdate();
    } else {
      NoDashUpdate();
    }
  }

  private bool CanDash() {
    bool baseCondition = powerup.CanDash && !dashInProgress && timeLeftElapsed <= 0;
    if (ground.IsGrounded) {
      return baseCondition;
    } else {
      return baseCondition && !haveDashed;
    }
  }

  private void DashUpdate() {
    bool interruptDashAfterWallHit = ShouldInterruptDashFromCollision();
    bool moveInDashDirection = input.InputDirection == dashDirection;
    if (moveInDashDirection && !interruptDashAfterWallHit && timeLeftElapsed > 0) {
      physics.Velocity.Value = new Vector2(
        dashTileVelocity * TileHelpers.TILE_SIZE * dashDirection.ToFloat(),
        0
      );
      timeLeftElapsed -= Time.deltaTime;
      animator.PlayDash(IsBackwardDash(dashDirection));
    } else {
      OnDashEnd();
    }
    if (!moveInDashDirection) {
      walk.SetFreezeMovement(interruptedDashFreezeTime);
    }
  }

  private bool ShouldInterruptDashFromCollision() {
    bool interruptDashAfterWallHit = false;
    bool hitAWall = physics.Velocity.CurrentCollision[dashDirection];
    if (hitAWall) {
      hitWallTime += Time.deltaTime;
      if (hitWallTime >= stopDashInWallTime) {
        interruptDashAfterWallHit = true;
      }
    } else {
      hitWallTime = 0;
    }

    return interruptDashAfterWallHit;
  }

  private void NoDashUpdate() {
    if (timeLeftElapsed > 0) {
      timeLeftElapsed -= Time.deltaTime;
    }

    if (ground.IsGrounded) {
      haveDashed = false;
    }
  }

  private void OnDashStart() {
    Debug.Log("[PlayerDash] Dash Start");
    sound.PlayDash();
    haveDashed = true;
    dashInProgress = true;
    timeLeftElapsed = dashDuration;
    dashDirection = input.InputDirection;
    isBackwardDash = IsBackwardDash(dashDirection);
    jump.PlayerDisable();
    velocityXBackup = physics.Velocity.X;
    gravityBackup = physics.Gravity.Scale;
    physics.Gravity.Scale = 0f;
  }

  private void OnDashEnd() {
    Debug.Log("[PlayerDash] Dash End");
    dashInProgress = false;
    timeLeftElapsed = dashDelay;
    jump.PlayerEnable();
    physics.Gravity.Scale = gravityBackup;
    physics.Velocity.X = velocityXBackup;
  }

  private bool IsBackwardDash(Direction2H dashDirection) {
    return playerFlip.Direction != dashDirection;
  }
}
