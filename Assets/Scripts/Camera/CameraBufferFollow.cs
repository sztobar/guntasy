using UnityEngine;
using System.Collections;

public class CameraBufferFollow : MonoBehaviour {

  [SerializeField]
  private new CircleCollider2D collider;

  [SerializeField]
  private Transform followTarget;

  [SerializeField]
  private float followSmoothing;

  [SerializeField]
  private float distanceToStopFollowing;

  private bool isFollowing;
  private float smoothing;

  public void SetSmoothing(float newSmoothing) {
    smoothing = newSmoothing;
  }

  public void ResetSmoothing() {
    smoothing = followSmoothing;
  }

  private void Awake() {
    ResetSmoothing();
  }

  private void Update() {
    if (!isFollowing && !IsInsideCollider(followTarget.position)) {
      isFollowing = true;
    }

    if (isFollowing) {
      transform.position = Vector2.Lerp(transform.position, followTarget.position, smoothing);
      if (Vector2.Distance(transform.position, followTarget.position) <= distanceToStopFollowing) {
        isFollowing = false;
      }
    }
  }

  private bool IsInsideCollider(Vector2 targetPosition) {
    return collider.OverlapPoint(targetPosition);
    //return Vector2.Distance(collider.transform.position, targetPosition) < collider.radius;
  }
}
