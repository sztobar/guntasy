using UnityEngine;
using Kite;

public class MovingBlockCollidable : MovingPlatformCollidablesBase, ICollidable {

  static readonly float UP_RAY_LENGTH = 1;

  [SerializeField] protected LayerMask collisionMask;
  [SerializeField] private BoxCollider2D boxCollider;

  private readonly PushablesInRaycastHits pushablesInRaycastHits = new PushablesInRaycastHits();
  private Vector2 allowedDeltaPosition;
  private BoxRaycaster raycaster;

  float ICollidable.GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) {
    if (allowedDeltaPosition != Vector2.zero && allowedDeltaPosition.HasValueInDirection(direction)) {
      return Mathf.Min(collideDistance, Mathf.Abs(allowedDeltaPosition[direction.ToVector2Index()]));
    }
    return 0;
  }

  void ICollidable.ForceMoveInto(Transform moving, float collideDistance, Direction4 direction) { }

  public override void TransferMovement(Vector2 deltaPosition) {
    allowedDeltaPosition = deltaPosition;
    TransferMovementForObjectsInPath(deltaPosition);
    if (deltaPosition.y <= UP_RAY_LENGTH) {
      TransferMovementForObjectsAbove(deltaPosition);
    }
    allowedDeltaPosition = Vector2.zero;
    pushablesInRaycastHits.Clear();
  }

  private void TransferMovementForObjectsInPath(Vector2 deltaPosition) {
    //RaycastHit2D[] results = raycaster.GetHits(transform.position, deltaPosition);
    //foreach ((_, PushableComponent pushable) in pushablesInRaycastHits.GetUnique(results)) {
    //  pushable.Push(deltaPosition, MoveMode.VerticalFirst);
    //}
  }

  private void TransferMovementForObjectsAbove(Vector2 deltaPosition) {
    //RaycastHit2D[] results = raycaster.GetRaycastHits(transform.position, UP_RAY_LENGTH, Direction4.Up, collisionMask);
    //foreach ((RaycastHit2D hit, PushableComponent pushable) in pushablesInRaycastHits.GetUnique(results)) {
    //  Vector2 pushAmount = deltaPosition + new Vector2(0, -UP_RAY_LENGTH * hit.fraction);
    //  pushable.Push(pushAmount, MoveMode.VerticalFirst);
    //}
  }

  private void Awake() {
    raycaster = new BoxRaycaster(boxCollider, Physics2D.GetLayerCollisionMask(gameObject.layer));
  }
}
