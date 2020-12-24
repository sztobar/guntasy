using UnityEngine;
using Kite;

public class PlayerJumpComponent : PlayerComponent {

  [SerializeField] private float jumpTileMaxHeight = 3f;

  [SerializeField] private float jumpTileMinHeight = 1f;

  [SerializeField] private float doubleJumpTileMaxHeight = 3f;

  [SerializeField] private float coyoteJumpTime = 0.1f;

  [SerializeField] private ParticleSystem jumpParticles;

  [SerializeField] private PlatformSkipabble platformSkippable;

  #region dependecies
  private PlayerSoundHandler sound;
  private PlayerGroundComponent ground;
  private PlayerWalkComponent walk;
  private PlayerInputHandler input;
  private PlayerPhysicsComponent physics;
  private PlayerAnimator animator;
  private PlayerPowerupHandler powerup;
  #endregion

  private float coyoteJumpTimeLeft;
  private bool jumpInProgress;
  private bool doubleJumped;

  private float InitialJumpVelocity => JumpVelocity(jumpTileMaxHeight);
  private float DoubleJumpVelocity => JumpVelocity(doubleJumpTileMaxHeight);
  private float TerminateJumpVelocity => Mathf.Sqrt(Mathf.Pow(InitialJumpVelocity, 2) - (2 * -physics.Gravity.G * TileHelpers.TileToWorld(jumpTileMaxHeight - jumpTileMinHeight)));

  public float JumpVelocity(float tileValue) => Mathf.Sqrt(2 * -physics.Gravity.G * TileHelpers.TileToWorld(tileValue));
  public Vector2 JumpVelocity(Vector2 tileVelocity) => new Vector2(TileHelpers.TileToWorld(tileVelocity.x), JumpVelocity(tileVelocity.y));

  public override void PlayerAwake(PlayerGameplayController controller) {
    ground = controller.Ground;
    walk = controller.Walk;
    input = controller.DI.Input;
    physics = controller.DI.Physics;
    animator = controller.DI.Animator;
    powerup = controller.DI.Powerup;
    sound = controller.DI.Sound;
  }

  protected override void PlayerFixedUpdateImpl() {
    bool isGrounded = ground.IsGrounded;
    StateUpdate(isGrounded);

    if (input.JumpDownPressed) {
      if (isGrounded) {
        platformSkippable.CanSkip = true;
      }
    } else if (input.JumpButtonPressed) {
      bool canGroundJump = isGrounded || coyoteJumpTimeLeft > 0;
      if (canGroundJump) {
        PerformJump();
      } else if (CanDoubleJump()) {
        PerformDoubleJump();
      }
    }

    if (jumpInProgress) {
      float termVelocity = TerminateJumpVelocity;
      if (!input.JumpButtonHeld && physics.Velocity.Y > termVelocity) {
        physics.Velocity.Y = termVelocity;
      }
    }

    if (!isGrounded) {
      AnimatorEffect();
    }
  }

  private bool CanDoubleJump() {
    return powerup.CanDoubleJump && !doubleJumped;
  }

  private void AnimatorEffect() {
    if (physics.Velocity.Y > 0) {
      if (doubleJumped) {
        animator.PlayDoubleJump();
      } else {
        animator.PlayJump();
      }
    } else {
      animator.PlayFall();
    }
  }

  private void StateUpdate(bool isGrounded) {
    if (isGrounded) {
      jumpInProgress = false;
      doubleJumped = false;
      coyoteJumpTimeLeft = coyoteJumpTime;
    } else if (!isGrounded && coyoteJumpTimeLeft > 0) {
      coyoteJumpTimeLeft -= Time.deltaTime;
    }
  }

  public void PerformExternalJump(Vector2 velocity) {
    physics.Velocity.Value = velocity;
    coyoteJumpTimeLeft = 0;
    jumpInProgress = true;
  }

  private void PerformJump() {
    Debug.Log("Perform Jump");
    sound.PlayJump();
    if (jumpParticles) {
      jumpParticles.Play();
    }
    physics.Velocity.Y = InitialJumpVelocity;
    coyoteJumpTimeLeft = 0;
    jumpInProgress = true;
    ground.IsGrounded = false;
    input.JumpButtonCancel();
  }

  private void PerformDoubleJump() {
    Debug.Log("Perform Double Jump");
    sound.PlayJump();
    if (jumpParticles) {
      jumpParticles.Play();
    }
    physics.Velocity.Y = DoubleJumpVelocity;
    jumpInProgress = true;
    doubleJumped = true;
  }
}
