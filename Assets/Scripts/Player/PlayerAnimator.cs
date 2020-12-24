using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IPlayerInjectable {

  public static readonly int StateHash = Animator.StringToHash("State");
  public static readonly int DirectionHash = Animator.StringToHash("Direction");

  [SerializeField]
  private Animator animator;

  private PlayerDodgeComponent dodgeComponent;
  private IWeaponAnimator weaponAnimator;

  public void Inject(PlayerDI di) {
    dodgeComponent = di.GameplayController.Dodge;
    di.WeaponArm.OnWeaponChange += HandleWeaponChange;
  }

  private void HandleWeaponChange(BaseWeaponController weapon) {
    weaponAnimator = weapon.DI.WeaponAnimator;
  }

  public void PlayIdle() {
    SetAnimatorState(State.Idle);
  }

  public void PlayWalk() {
    SetAnimatorState(State.Walk);
  }

  public void PlayJump() {
    if (!IsJumpLoop()) {
      SetAnimatorState(State.JumpBegin);
    }
  }

  public void OnJumpBeginEnd() {
    SetAnimatorState(State.JumpLoop);
  }

  public void PlayDoubleJump() {
    if (!IsDoubleJumpLoop()) {
      SetAnimatorState(State.DoubleJumpBegin);
    }
  }

  public void OnDoubleJumpBeginEnd() {
    SetAnimatorState(State.DoubleJumpLoop);
  }

  public void PlayFall() {
    SetAnimatorState(State.Fall);
  }

  public void PlayDash(bool backwardDash) {
    if (backwardDash) {
      SetAnimatorState(State.BackwardDash);
    } else {
      SetAnimatorState(State.Dash);
    }
  }

  public void PlayDodgeLeap() {
    SetAnimatorState(State.DodgeLeap);
  }

  public void StartDodgeLeap() {
    weaponAnimator.PlayDodgeLeap();
  }

  /// <summary>
  /// Called from Animation
  /// </summary>
  public void OnDodgeLeapAnimationEnded() {
    dodgeComponent.OnDodgeLeapAnimationEnded();
  }

  public void PlayDodgeRoll() {
    SetAnimatorState(State.DodgeRoll);
  }

  public void StartDodgeRoll() {
    weaponAnimator.PlayDodgeRoll();
  }

  private void SetAnimatorState(State stateValue) {
    animator.SetInteger(StateHash, (int)stateValue);
  }

  enum State {
    Idle = 1,
    Walk = 2,
    JumpBegin = 3,
    JumpLoop = 4,
    DoubleJumpBegin = 5,
    DoubleJumpLoop = 6,
    Fall = 7,
    Dash = 8,
    BackwardDash = 9,
    DodgeLeap = 10,
    DodgeRoll = 11,
  }

  public void SetForward() {
    SetAnimatorDirection(Direction.Forward);
  }

  public void SetBackward() {
    SetAnimatorDirection(Direction.Backward);
  }

  private void SetAnimatorDirection(Direction directionValue) {
    animator.SetFloat(DirectionHash, (float)directionValue);
  }

  enum Direction {
    Forward = 1,
    Backward = -1
  }

  private bool IsJumpLoop() {
    return animator.GetInteger(StateHash) == (int)State.JumpLoop;
  }

  private bool IsDoubleJumpLoop() {
    return animator.GetInteger(StateHash) == (int)State.DoubleJumpLoop;
  }
}
