using UnityEngine;
using System.Collections;

namespace Explosion {
  public class BigExplosion : MonoBehaviour {

    [SerializeField]
    private ExplosionAnimator[] explosionAnimators;

    [SerializeField]
    private float randomPositionOffset = 5;

    private void Awake() {
      foreach(ExplosionAnimator animator in explosionAnimators) {
        animator.transform.Translate(GetRandomTranslationOffset());
      }
    }

    private Vector2 GetRandomTranslationOffset() {
      Vector2 floatVector = Random.insideUnitCircle * randomPositionOffset;
      return new Vector2(
        Mathf.Round(floatVector.x),
        Mathf.Round(floatVector.y)
      );
    }
  }
}