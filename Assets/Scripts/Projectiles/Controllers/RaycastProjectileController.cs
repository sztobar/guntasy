using UnityEngine;
using System.Collections;
using Kite;

public class RaycastProjectileController : MonoBehaviour {

  //[SerializeField]
  //private ColliderCollisionEmitter colliderCollisionEmitter;

  [SerializeField]
  private EmitDestructionItem emitDestructionItem;

  [SerializeField]
  private BaseProjectilePiercing projectilePiercing;

  [SerializeField]
  private BaseProjectileMovement projectileMovement;

  private float trailLifeTime;
  private float currentRayDistance;
  private float rayLength;
  private Vector2 startPosition;
  private Vector2 endPosition;

  private bool HandleCharacterCollision(RaycastHit2D hit) {
    if (projectilePiercing.Inflict(hit)) {
      rayLength = (hit.point - (Vector2)transform.position).magnitude;
      return true;
    }
    return false;
  }

  private void DestroyProjectile() {
    enabled = false;
    emitDestructionItem.DestroyGameObjectAfter(trailLifeTime);
  }


  private void Awake() {
    startPosition = transform.position;
    CheckRaycastCollisions();

    TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
    trailLifeTime = trailRenderer.time;
  }

  private void CheckRaycastCollisions() {
    RaycastCollider raycastCollider = new RaycastCollider();
    Vector2 direction = Vector2Extensions.QuaternionToVector2(transform.rotation);
    raycastCollider.Cast(transform.position, direction, gameObject.layer);
    rayLength = raycastCollider.RayLength;
    foreach (RaycastHit2D hit in raycastCollider.Hits) {
      CollisionType type = CollisionTypeExtensions.FromRaycastHit2D(hit);
      bool interruptCollisions = HandleRaycastCollision(hit, type);
      if (interruptCollisions) {
        break;
      }
    }
    endPosition = startPosition + direction * rayLength;
  }

  private bool HandleRaycastCollision(RaycastHit2D hit, CollisionType type) {
    if (type == CollisionType.Character) {
      return HandleCharacterCollision(hit);
    }
    return false;
  }

  void Update() {
    float velocity = projectileMovement.GetVelocity().magnitude;
    float ds = velocity * Time.deltaTime;
    currentRayDistance += ds;
    float t = currentRayDistance / rayLength;
    transform.position = Vector2.Lerp(startPosition, endPosition, currentRayDistance / rayLength);
    if (t >= 1) {
      DestroyProjectile();
    }
  }
}
