using UnityEngine;
using Kite;

public class GrenadeMovement : BaseProjectileMovement {

  [SerializeField]
  private float startTileVelocityX = 5f;

  [SerializeField]
  private float endTileVelocityX = 20f;

  [SerializeField]
  private float startVelocityDistanceX = 32f;

  [SerializeField]
  private float endVelocityDistanceX = 300f;

  [SerializeField]
  private float maxTileVelocityY = 32f;

  [SerializeField]
  private new Rigidbody2D rigidbody;

  [SerializeField, HideInInspector]
  private Vector2 fireVelocity;

  public float G => Physics2D.gravity.y * rigidbody.gravityScale;
  private float MaxVelocityY => maxTileVelocityY * TileHelpers.TILE_SIZE;

  private void Awake() {
    rigidbody.AddRelativeForce(Vector2.right * fireVelocity.magnitude, ForceMode2D.Impulse);
  }

  public override Vector2 GetVelocity() {
    return rigidbody.velocity;
  }

  public void SetFireVelocityFor(Vector2 ds) {
    float vx = GetVelocityX(ds.x);
    float timeToReachTarget = ds.x / vx;

    float vy = ds.y / timeToReachTarget - 0.5f * G * timeToReachTarget;
    vy = Mathf.Min(vy, MaxVelocityY);

    fireVelocity = new Vector2(vx, vy);
  }

  public Vector2 GetFireVelocity() {
    return fireVelocity;
  }

  public float GetVelocityX(float distanceX) {
    float absDistanceX = Mathf.Abs(distanceX);
    float signDistanceX = Mathf.Sign(distanceX);
    if (absDistanceX < startVelocityDistanceX) {
      return startTileVelocityX * (absDistanceX / startVelocityDistanceX) * TileHelpers.TILE_SIZE * signDistanceX;
    }
    float clampedDistanceX = Mathf.Clamp(absDistanceX, startVelocityDistanceX, endVelocityDistanceX);
    float distanceValue = clampedDistanceX - startVelocityDistanceX;
    float distanceRange = endVelocityDistanceX - startVelocityDistanceX;
    float t = distanceValue / distanceRange;
    return Mathf.Lerp(startTileVelocityX, endTileVelocityX, t) * TileHelpers.TILE_SIZE * signDistanceX;
  }

  /// <summary>
  /// Perfect angle might not exists
  /// </summary>
  public Vector2 GetSafeDirection(Vector2 ds) {
    float velocity = 20f; // <= this should be member field
    float acosSign = Mathf.Sign(ds.y);
    float h = -ds.y;
    float x = Mathf.Abs(ds.x);
    float g = G;
    float v0 = velocity;

    float x2 = x * x;
    float v02 = v0 * v0;
    float h2 = h * h;

    float acosValue = ((-g * x2 / v02) - h) / (Mathf.Sign(h) * Mathf.Sqrt(h2 + x2));
    if (acosValue < -1 || acosValue > 1) {
      return Vector2.zero;
    } else {
      float acosRadians = Mathf.Acos(acosValue);
      float acosAngle = Mathf.Rad2Deg * acosRadians;
      acosAngle = Mathf.Sign(acosSign) * acosAngle;

      float atanValue = x / h;
      float atanRadians = Mathf.Atan(atanValue);
      float atanAngle = Mathf.Rad2Deg * atanRadians;
      float theta = (acosAngle + atanAngle) / 2;

      Vector2 fireDirection = Vector2Extensions.DegreeToVector2(theta);
      fireDirection.x *= Mathf.Sign(ds.x);
      return fireDirection;
    }
  }
}
