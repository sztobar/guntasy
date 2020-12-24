using UnityEngine;

namespace Kite {
  public readonly struct RaycasterHit {

    private readonly float distanceToHit;
    private readonly Vector2 point;
    private readonly Transform transform;
    private readonly Direction4 rayDirection;

    public Transform Transform => transform;
    public Vector2 Point => point;
    public float DistanceToHit => distanceToHit;
    public Direction4 RayDirection => rayDirection;

    public RaycasterHit(Transform transform, Vector2 point, Vector2 normal, float distanceToHit) {
      this.transform = transform;
      this.point = point;
      this.distanceToHit = distanceToHit;
      rayDirection = Direction4Helpers.FromVector2Normal(normal);
    }

    public RaycasterHit(RaycastHit2D hit) :
      this(
        transform: hit.transform,
        point: hit.point,
        normal: hit.normal,
        distanceToHit: hit.distance
      ) { }
    
    public float GetCollideDistance(float wantedToMove, float skinWidth = Constants.SKIN_WIDTH) {
      return Mathf.Max(wantedToMove - distanceToHit - skinWidth, 0);
    }
  }
}