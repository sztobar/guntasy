using UnityEngine;

public class GrenadeCursor : MonoBehaviour {

  public static Vector2 GetPosition(Vector2 velocity, Vector2 position, float g, float t) {
    return new Vector2(
      position.x + velocity.x * t,
      position.y + velocity.y * t + 0.5f * g * t * t
    );
  }

  [SerializeField]
  private GrenadeAimCrosshair[] crosshairs;

  public void SetPositionFor(GrenadeMovement movement, Vector2 startPosition, Vector2 distance) {
    float g = movement.G;
    Vector2 fireVelocity = movement.GetFireVelocity();
    float projectileTime = distance.x / fireVelocity.x;
    float aimPercentageDelta = 0.1f;
    for (int i = 0; i < crosshairs.Length; i++) {
      GrenadeAimCrosshair crosshair = crosshairs[i];
      float t = crosshair.Percentage * projectileTime;
      Vector2 crosshairPosition = GetPosition(fireVelocity, startPosition, g, t);
      float aimT = (crosshair.Percentage + aimPercentageDelta) * projectileTime;
      Vector2 crosshairAimPosition = GetPosition(fireVelocity, startPosition, g, aimT);
      crosshair.SetPosition(crosshairPosition, Quaternion.LookRotation(Vector3.forward, crosshairAimPosition - crosshairPosition));
    }
  }
}