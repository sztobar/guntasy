using UnityEngine;
using System.Collections;
using Kite;

namespace Enemies.Components {
  public class TankBodyAnimator : MonoBehaviour {

    private static readonly int ANIMATION_SPEED_HASH = Animator.StringToHash("AnimationSpeed");

    [SerializeField]
    private Animator animator;

    private float animationDirection = 1;

    private void SetAnimationSpeed(float speed) {
      animator.SetFloat(ANIMATION_SPEED_HASH, speed);
    }

    public void UpdateAnimationSpeed(float velocityX) {
      float movementDirection = -Mathf.Sign(velocityX);
      if (animationDirection != movementDirection) {
        animationDirection = movementDirection;
        SetAnimationSpeed(animationDirection);
      }
    }
  }
}