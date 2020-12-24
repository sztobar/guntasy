using UnityEngine;
using Kite;

public class PlayerWalkComponent : PlayerComponent {

  [SerializeField]
  private float movementTileSpeed = 5f;

  [SerializeField]
  private ParticleSystem walkParticles;

  #region dependencies
  private PlayerPhysicsComponent physics;
  private PlayerInputHandler input;
  private PlayerAnimator animator;
  private HorizontalFlipComponent flip;
  private PlayerGroundComponent ground;
  private PlayerSoundHandler sound;
  #endregion

  private float freezeMovementTimeLeft;

  public float MovementSpeed => movementTileSpeed * TileHelpers.TILE_SIZE;

  public void SetFreezeMovement(float duration) {
    freezeMovementTimeLeft = duration;
  }

  public override void PlayerAwake(PlayerGameplayController controller) {
    physics = controller.DI.Physics;
    input = controller.DI.Input;
    animator = controller.DI.Animator;
    flip = controller.DI.Flip;
    sound = controller.DI.Sound;
    ground = controller.Ground;
  }

  protected override void PlayerFixedUpdateImpl() {
    float moveInputX = input.MoveInput;
    if (freezeMovementTimeLeft > 0) {
      FrozenMovementUpdate();
    } else {
      float velocityX = GetMoveVelocityX(moveInputX);
      physics.Velocity.X = velocityX;
    }
    MoveInputEffects(moveInputX);
  }

  private void FrozenMovementUpdate() {
    if (ground.IsGrounded) {
      freezeMovementTimeLeft = 0;
    }
    if (freezeMovementTimeLeft > 0) {
      freezeMovementTimeLeft -= Time.deltaTime;
      physics.Velocity.X = 0;
    }
  }

  private float GetMoveVelocityX(float moveInputX) {
    float targetVelocity = moveInputX * MovementSpeed;
    return targetVelocity;
  }

  private void MoveInputEffects(float moveInputX) {
    sound.PlayWalk(moveInputX != 0 && ground.IsGrounded);
    if (moveInputX != 0) {
      var movementDirection = Direction2Helpers.FromFloat(moveInputX);
      var animationDirection = flip.Direction;
      if (movementDirection != animationDirection) {
        animator.SetBackward();
      } else {
        animator.SetForward();
      }

      if (ground.IsGrounded) {
        animator.PlayWalk();

        if (walkParticles && !walkParticles.isPlaying) {
          walkParticles.Play();
        }
      } else {
        if (walkParticles && walkParticles.isPlaying) {
          walkParticles.Stop();
        }
      }
    } else {
      if (ground.IsGrounded) {
        animator.PlayIdle();
      }
      if (walkParticles && walkParticles.isPlaying) {
        walkParticles.Stop();
      }
    }
  }
}
