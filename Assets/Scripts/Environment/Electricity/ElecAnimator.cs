using UnityEngine;
using System.Collections;

public class ElecAnimator : MonoBehaviour {

  private static int CURRENT_HASH = Animator.StringToHash("Current");

  [SerializeField]
  Animator animator;

  public void CurrentOn() {
    if (gameObject.activeSelf) {
      animator.SetBool(CURRENT_HASH, true);
    }
  }

  public void CurrentOff() {
    if (gameObject.activeSelf) {
      animator.SetBool(CURRENT_HASH, false);
    }
  }
}
