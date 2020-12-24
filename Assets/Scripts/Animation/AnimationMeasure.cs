using UnityEngine;
using System.Collections;

public class AnimationMeasure : StateMachineBehaviour {

  private float startTime;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateEnter(animator, stateInfo, layerIndex);
    startTime = Time.timeSinceLevelLoad;
  }

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateExit(animator, stateInfo, layerIndex);
    float endTime = Time.timeSinceLevelLoad;
    float duration = endTime - startTime;
    Debug.Log($"[AnimationMeasure] duration: {duration}ms");
  }
}
