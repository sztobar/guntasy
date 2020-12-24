using UnityEngine;
using System.Collections;

namespace Kite {

  [RequireComponent(typeof(SpriteRenderer))]
  public class FlashSprite : MonoBehaviour {

    [SerializeField]
    private float flashInterval = 0.05f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public bool IsFlashing { get; private set; }

    public void SetFlash(float duration) {
      StartCoroutine(StartFlash(duration));
    }

    private IEnumerator StartFlash(float duration) {
      IsFlashing = true;

      Color normalColor = spriteRenderer.color;
      Color semiTransparentColor = normalColor;
      semiTransparentColor.a = 0.5f;

      int steps = Mathf.CeilToInt(duration / (flashInterval * 2));
      for (int i = 0; i < steps; i++) {
        spriteRenderer.color = semiTransparentColor;
        yield return new WaitForPlaySeconds(flashInterval);

        spriteRenderer.color = normalColor;
        yield return new WaitForPlaySeconds(flashInterval);
      }
      IsFlashing = false;
    }
  }
}
