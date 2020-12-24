using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input {
  public class ThrottleAxis {

    private readonly float waitTime;

    private float elapsedTime;
    private bool inputInProgress;

    public Action<float> OnEmit { get; set; } = delegate { };

    public ThrottleAxis(InputAction action, float wait = 0.5f) {
      waitTime = wait;
      action.started += HandleActionStarted;
      action.canceled += HandleActionCanceled;
    }

    private void HandleActionCanceled(InputAction.CallbackContext ctx) {
      inputInProgress = false;
    }

    private void HandleActionStarted(InputAction.CallbackContext ctx) {
      float value = ctx.ReadValue<float>();
      if (inputInProgress) {
        if (elapsedTime >= waitTime) {
          elapsedTime -= waitTime;
          OnEmit(value);
        }
        elapsedTime += Time.unscaledDeltaTime;
      } else {
        elapsedTime = 0;
        inputInProgress = true;
        OnEmit(value);
      }
    }
  }
}