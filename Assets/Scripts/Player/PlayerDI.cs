using UnityEngine;
using Kite;

public class PlayerDI : MonoBehaviour {

  [SerializeField] private PlayerGameplayController gameplayController;
  [SerializeField] private PlayerAnimator animator;
  [SerializeField] private Direction3Animator bodyAnimator;
  [SerializeField] private PlayerPhysicsComponent physics;
  [SerializeField] private PlayerInputHandler input;
  [SerializeField] private HorizontalFlipComponent flip;
  [SerializeField] private PlayerPowerupHandler powerup;
  [SerializeField] private PlayerCollisionHandler collision;
  [SerializeField] private PlayerHealthHandler health;
  [SerializeField] private PlayerSoundHandler sound;
  [SerializeField] private PlayerZappedHandler zapped;
  [SerializeField] private PlayerWeaponArm weaponArm;
  [SerializeField] private PlayerCameraConfiner playerCamera;

  public PlayerGameplayController GameplayController => gameplayController;
  public PlayerAnimator Animator => animator;
  public Direction3Animator BodyAnimator => bodyAnimator;
  public PlayerPhysicsComponent Physics => physics;
  public PlayerInputHandler Input => input;
  public HorizontalFlipComponent Flip => flip;
  public PlayerPowerupHandler Powerup => powerup;
  public PlayerCollisionHandler Collision => collision;
  public PlayerHealthHandler Health => health;
  public PlayerSoundHandler Sound => sound;
  public PlayerZappedHandler Zapped => zapped;
  public PlayerWeaponArm WeaponArm => weaponArm;
  public PlayerCameraConfiner Camera => playerCamera;

  private void Start() {
    animator.Inject(this);
    input.Inject(this);
    powerup.Inject(this);
    collision.Inject(this);
    health.Inject(this);
    sound.Inject(this);
    zapped.Inject(this);
    playerCamera.Inject(this);

    weaponArm.Inject(this);
  }
}
