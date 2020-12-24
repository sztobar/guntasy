using UnityEngine;
using UnityEngine.InputSystem;

namespace Common {
  public class MaterialTintColor : MonoBehaviour {

    [SerializeField]
    private Material material;

    [SerializeField]
    private Color materialTintColor;

    [SerializeField]
    private float tintFadeTime;

    [SerializeField]
    private bool cloneMaterial;

    private SpriteRenderer[] applyToSprites;

    private Color initialTintColor;
    private float tintFadeElapsedTimeLeft;

    public void Flash() {
      materialTintColor.a = 1;
      tintFadeElapsedTimeLeft = tintFadeTime;
    }

    private void Awake() {
      if (cloneMaterial) {
        material = new Material(material);
        ApplyToSpritesInChildren();
      } else {
        initialTintColor = material.GetColor("_Tint");
      }
      material.SetColor("_Tint", materialTintColor);
    }

    private void OnDisable() {
      if (!cloneMaterial) {
        material.SetColor("_Tint", initialTintColor);
      }
    }

    private void ApplyToSpritesInChildren() {
      applyToSprites = GetComponentsInChildren<SpriteRenderer>();
      foreach(var sprite in applyToSprites) {
        sprite.material = material;
      }
    }

    private void Update() {
      if (tintFadeElapsedTimeLeft >= 0) {
        materialTintColor.a = Mathf.Lerp(0, 1, tintFadeElapsedTimeLeft / tintFadeTime);
        material.SetColor("_Tint", materialTintColor);
        tintFadeElapsedTimeLeft -= Time.deltaTime;
        if (tintFadeElapsedTimeLeft <= 0) {
          materialTintColor.a = 0;
          material.SetColor("_Tint", materialTintColor);
        }
      }
    }
  }
}