using Input;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class TriangleSlider : MonoBehaviour {

  private static readonly float MIXER_MIN_VOLUME = -80f;
  private static readonly float MIXER_MAX_VOLUME = 0f;

  [SerializeField]
  private new TriangleSliderRenderer renderer;

  [SerializeField]
  private AudioMixer mixer;

  [SerializeField]
  private string mixerParam;

  private InputActions input;
  private ThrottleAxis leftRightInput;

  public void Activate() {
    if (input == null) {
      input = new InputActions();
      leftRightInput = new ThrottleAxis(input.Menu.LeftRightMovement, wait: 0.2f);
      leftRightInput.OnEmit += HandleLeftRightInput;
    }
    renderer.ShowColumnSelector();
    input.Menu.Enable();
  }

  private void HandleLeftRightInput(float value) {
    renderer.CurrentValue += (int)value;
    //renderer.ModifyValue((int)value);
    float volume = Mathf.Lerp(MIXER_MIN_VOLUME, MIXER_MAX_VOLUME, renderer.GetPercentageValue());
    mixer.SetFloat(mixerParam, volume);
  }

  public void Deactivate() {
    input.Menu.Disable();
    renderer.HideColumnSelector();
  }

  private void OnEnable() {
    float volume;
    mixer.GetFloat(mixerParam, out volume);
    float sliderPercentage = Mathf.InverseLerp(MIXER_MIN_VOLUME, MIXER_MAX_VOLUME, volume);
    renderer.SetPercentage(sliderPercentage);
    //Debug.Log($"slider value {sliderPercentage}");
  }
}
