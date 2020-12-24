using System;
using UnityEngine;

namespace Kite {

  public class WaitForAnimationEvent<TAnimatorEventEmitter, TAnimationEvent> : CustomYieldInstruction
    where TAnimatorEventEmitter : IAnimatorEventEmitter<TAnimationEvent>
    where TAnimationEvent : Enum
  {

    private bool animationEventEmitted = false;
    private readonly TAnimationEvent waitForAnimationEvent;
    private readonly TAnimatorEventEmitter animator;

    public WaitForAnimationEvent(TAnimatorEventEmitter animator, TAnimationEvent animationEvent) {
      waitForAnimationEvent = animationEvent;
      this.animator = animator;
      animator.OnAnimationEvent += HandleAnimationEvent;
    }

    private void HandleAnimationEvent(TAnimationEvent animationEvent) {
      if (animationEvent.Equals(waitForAnimationEvent)) {
        animationEventEmitted = true;
        animator.OnAnimationEvent -= HandleAnimationEvent;
      }
    }

    public override bool keepWaiting => animationEventEmitted != true;
  }
}
