using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerBodyAnimator : MonoBehaviour {

  public static readonly int StateHash = Animator.StringToHash("State");
  private Animator animator;

  public void PlayUp() {
    SetAnimatorState(State.Up);
  }

  public void PlayFront() {
    SetAnimatorState(State.Front);
  }

  public void PlayDown() {
    SetAnimatorState(State.Down);
  }

  private void SetAnimatorState(State stateValue) {
    animator.SetInteger(StateHash, (int)stateValue);
  }

  enum State {
    Up = 1,
    Front = 2,
    Down = 3,
  }

  private void Awake() {
    animator = GetComponent<Animator>();
  }
}
