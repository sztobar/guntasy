using UnityEngine;
using UnityEngine.InputSystem;

namespace Common {

  public class FlashTintColorMaterial : MonoBehaviour {

    [SerializeField]
    private float flashInterval = 0.05f;

    [SerializeField]
    private float flashDuration = 0.5f;

    [SerializeField]
    private Material material;

    private Color initialColor;
    private float intervalTimeElapsed;
    private float durationTimeElapsed;
    private bool transparent;
    private Color transparentColor;
    private float currentFlashDuration;

    public bool IsFlashing { get; private set; }

    private void Awake() {
      initialColor = material.GetColor("_Color");
      transparentColor = initialColor;
      transparentColor.a = 0.25f;
    }

    private void OnDisable() {
      material.SetColor("_Color", initialColor);
    }

    public void StartFlash() {
      currentFlashDuration = flashDuration;
      InitStartFlashParams();
    }

    public void StartFlash(float duration) {
      currentFlashDuration = duration;
      InitStartFlashParams();
    }

    private void InitStartFlashParams() { 
      intervalTimeElapsed = 0;
      durationTimeElapsed = 0;
      transparent = false;
      IsFlashing = true;
    }

    void FlashUpdate() {
      durationTimeElapsed += Time.deltaTime;
      intervalTimeElapsed += Time.deltaTime;

      if (intervalTimeElapsed >= flashInterval) {
        intervalTimeElapsed -= flashInterval;
        FlashToggle();
      }
      if (durationTimeElapsed >= currentFlashDuration) {
        IsFlashing = false;
        SetSolid();
      }
    }

    private void FlashToggle() {
      if (transparent) {
        SetSolid();
      } else {
        SetTransparent();
      }
    }

    private void SetTransparent() {
      transparent = true;
      material.SetColor("_Color", transparentColor);
    }

    private void SetSolid() {
      transparent = false;
      material.SetColor("_Color", initialColor);
    }

    private void Update() {
      if (IsFlashing) {
        FlashUpdate();
      }

#if UNITY_EDITOR
      if (Keyboard.current.qKey.isPressed) {
        StartFlash();
      }
#endif
    }
  }
}
