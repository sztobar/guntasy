using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Direction3Animator : MonoBehaviour {

  static readonly int DirectionHash = Animator.StringToHash("Direction");

  private Animator animator;

  public void LookUp() {
    animator.SetFloat(DirectionHash, (float)Direction3.Up);
  }

  public void LookFront() {
    animator.SetFloat(DirectionHash, (float)Direction3.Front);
  }

  public void SetDirection(Direction3 direction) {
    animator.SetFloat(DirectionHash, (float)direction);
  }

  public void LookDown() {
    animator.SetFloat(DirectionHash, (float)Direction3.Down);
  }

  private void Awake() {
    animator = GetComponent<Animator>();
  }
}
