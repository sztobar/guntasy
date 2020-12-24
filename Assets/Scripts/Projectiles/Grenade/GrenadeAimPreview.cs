using UnityEngine;

public class GrenadeAimPreview : MonoBehaviour {

  [SerializeField] private LineRenderer lineRenderer;
  [SerializeField] private int points;

  public void SetPreview(GrenadeMovement movement, Vector2 startPosition, Vector2 distance) {
    float g = movement.G;
    Vector2 fireVelocity = movement.GetFireVelocity();
    float projectileTime = distance.x / fireVelocity.x;
    lineRenderer.positionCount = points;
    for (int i = 0; i < points; i++) {
      float pointTime = i / (points - 1.0f);
      float t = pointTime * projectileTime;
      Vector2 pointPosition = GrenadeCursor.GetPosition(fireVelocity, startPosition, g, t);
      lineRenderer.SetPosition(i, pointPosition);
    }
  }
}
