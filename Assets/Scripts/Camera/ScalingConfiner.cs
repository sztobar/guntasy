using UnityEngine;
using System.Collections;

public class ScalingConfiner : MonoBehaviour {

  [SerializeField]
  private float transitionTime = 1f;

  private float transitionTimeElapsed;
  private bool transitionInProgress;
  private new Collider2D collider;
  private float startScale = 1f;
  private float endScale = 1f;

  public Vector2 ClosestPoint(Vector2 position) {
    Vector2 myPosition = transform.position;
    return collider.ClosestPoint(position + myPosition) - myPosition;
  }

  public void SetScale(float newScale) {
    if (newScale == endScale) {
      return;
    }
    startScale = endScale;
    endScale = newScale;
    transitionTimeElapsed = 0;
    transitionInProgress = true;
  }

  public void ResetScale() {
    SetScale(1f);
  }

  private void Awake() {
    collider = GetComponent<Collider2D>();
  }

  private void Update() {
    if (transitionInProgress) {
      float timePercentage = transitionTimeElapsed / transitionTime;
      float scaleValue = Mathf.Lerp(startScale, endScale, timePercentage);
      transform.localScale = Vector3.one * scaleValue;
      transitionTimeElapsed += Time.deltaTime;

      if (transitionTimeElapsed >= transitionTime) {
        transitionInProgress = false;
        transform.localScale = Vector3.one * endScale;
      }
    }
  }

}
