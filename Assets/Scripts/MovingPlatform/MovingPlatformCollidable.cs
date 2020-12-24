using UnityEngine;
using Kite;
using System.Collections.Generic;

public class MovingPlatformCollidable : MovingPlatformCollidablesBase, ICollidable {

  static readonly float UP_RAY_LENGTH = 1;
  static readonly ContactFilter2D contactFilter = new ContactFilter2D { };
  static readonly ContactPoint2D[] contacts = new ContactPoint2D[4];

  [SerializeField] protected LayerMask collisionMask;
  [SerializeField] private EdgeCollider2D edgeCollider;
  [SerializeField] private BoxCollider2D boxCollider;
  [SerializeField] private new Rigidbody2D rigidbody;

  private readonly PushablesInRaycastHits pushablesInRaycastHits = new PushablesInRaycastHits();
  private Vector2 allowedDeltaPosition;
  private BoxRaycaster raycaster;

  float ICollidable.GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) {
    if (allowedDeltaPosition == Vector2.zero) {
      //return PlatformCollidableHelpers.GetEdgeColliderAllowedMovementInto(wantsToMove, direction, collideDistance, ref hit);
      return PlatformCollidableHelpers.GetBoxColliderAllowedMovementInto(wantsToMove, collideDistance, direction, hitPoint, boxCollider);
    }
    if (allowedDeltaPosition.HasValueInDirection(direction)) {
      return Mathf.Min(collideDistance, Mathf.Abs(allowedDeltaPosition[direction.ToVector2Index()]));
    }
    return 0;
  }

  void ICollidable.ForceMoveInto(Transform moving, float collideDistance, Direction4 direction) { }

  public override void TransferMovement(Vector2 deltaPosition) {
    allowedDeltaPosition = deltaPosition;
    TransferMovementForObjectsAbove_bck(deltaPosition);
    allowedDeltaPosition = Vector2.zero;
  }

  private void TransferMovementForObjectsAbove(Vector2 deltaPosition) {
    int contactsLength = rigidbody.GetContacts(contacts);
    HashSet<Rigidbody2D> transfered = new HashSet<Rigidbody2D>();
    for(int i = 0; i < contactsLength; i++) {
      ContactPoint2D contact = contacts[i];
      if (contact.normal != Vector2.down || transfered.Contains(contact.rigidbody))
        continue;
      transfered.Add(contact.rigidbody);
      PushableComponent pushable = contact.rigidbody.GetComponent<PushableComponent>();
      if (pushable)
        pushable.Push(deltaPosition, MoveMode.VerticalFirst);
    }
  }

  private void TransferMovementForObjectsAbove_bck(Vector2 deltaPosition) {
    float rayLength = Mathf.Max(deltaPosition.y, UP_RAY_LENGTH);
    //RaycastHit2D[] results = raycaster.GetRaycastHits(transform.position, rayLength, Direction4.Up, collisionMask);
    //foreach ((RaycastHit2D hit, PushableComponent pushable) in pushablesInRaycastHits.GetUnique(results)) {
    //  float hitPointY = hit.point.y;
    //  float colliderMinY = hit.collider.bounds.min.y;
    //  if (!Mathf.Approximately(hitPointY, colliderMinY) && hitPointY < colliderMinY) {
    //    Debug.Log($"Platform through hitPointY: {hitPointY}; colliderMinY: {colliderMinY}");
    //    continue;
    //  }

    //  Vector2 pushAmount = deltaPosition + new Vector2(0, -UP_RAY_LENGTH * hit.fraction);
    //  pushable.Push(pushAmount, MoveMode.VerticalFirst);
    //}
    pushablesInRaycastHits.Clear();
  }

  private void Awake() {
    //raycaster = new Raycaster(edgeCollider);
    raycaster = new BoxRaycaster(boxCollider, Physics2D.GetLayerCollisionMask(gameObject.layer));
  }
}
