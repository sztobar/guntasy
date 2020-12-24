using UnityEngine;
using System.Collections.Generic;

namespace Kite {

  public class OldPhysicsComponent : MonoBehaviour {

    [SerializeField] private bool manualUpdate;

    [SerializeField] private float gravityScale = 5f;

    [SerializeField] protected new BoxCollider2D collider;

    [SerializeField] protected new Rigidbody2D rigidbody;

    [SerializeField] protected LayerMask collisionMask;

    private Vector2 velocity;
    protected Vector2 currentFramePositionDelta;
    protected BoxRaycaster raycaster;

    protected CollisionState currentCollisionState;
    protected CollisionState previousCollisionState;

    public float G => Physics2D.gravity.y * gravityScale * TileHelpers.TILE_SIZE;
    public Bounds Bounds => collider.bounds;
    public int LayerMaskValue => collisionMask.value;
    public bool Frozen { get; set; }
    public float GravityScale {
      set => gravityScale = value;
      get => gravityScale;
    }

    public CollisionState CurrentCollisionState => currentCollisionState;
    public CollisionState PreviousCollisionState => previousCollisionState;

    public Vector2 Velocity {
      get => velocity;
      set {
        velocity = value;
      }
    }

    public bool IsGrounded() {
      return currentCollisionState[Direction4.Down];
    }

    // todo refactor pls
    public bool ReachedEdge(Direction2H direction, float distance) {
      Bounds bounds = collider.bounds;
      bounds.Expand(new Vector2(0, -2 * Constants.SKIN_WIDTH));
      Vector2 origin = new Vector2(bounds.center.x + (direction.ToFloat() * (bounds.extents.x + distance)), bounds.min.y);
      float raycastLength = Constants.PIXEL_SIZE + Constants.SKIN_WIDTH;
      RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, raycastLength, collisionMask.value);
      return hit.collider == null;
    }

    public virtual Vector2 Move(Vector2 moveValue, MoveMode mode = MoveMode.HorizontalFirst) {
      Vector2 position = rigidbody.position;
      Vector2 moveResult = Vector2.zero;

      int[] vectorIndexes = mode.GetVectorIndexes();
      for (int i = 0; i < vectorIndexes.Length; i++) {
        int vectorIndex = vectorIndexes[i];
        float moveAmount = Mathf.Abs(moveValue[vectorIndex]);
        if (moveAmount < Mathf.Epsilon) {
          continue;
        }
        Direction4 moveDirection = moveValue.ToDirection4InAxis(vectorIndex);
        Vector2 origin = position + moveResult;
        moveResult += PerformMoveInAxis(origin, moveAmount, moveDirection);
      }

      return moveResult;
    }

    public virtual Vector2 Push(Vector2 value, MoveMode mode = MoveMode.HorizontalFirst) {
      Vector2 pushResult = Move(value, mode);

      //transform.position += new Vector3(pushResult.x, pushResult.y);
      rigidbody.position += pushResult;

      return pushResult;
    }

    protected Vector2 PerformMoveInAxis(Vector2 origin, float moveAmount, Direction4 moveDirection) {
      float moveResult = CheckCollisionsForMovement(origin, moveAmount, moveDirection);
      return moveDirection.ToVector2(moveResult);
    }

    public void SetVelocityY(float velocityY) {
      velocity.y = velocityY;
    }

    public void SetVelocityX(float velocityX) {
      velocity.x = velocityX;
    }

    void Awake() {
      raycaster = new BoxRaycaster(collider, Physics2D.GetLayerCollisionMask(gameObject.layer));
    }

    void FixedUpdate() {
      if (manualUpdate || Frozen) { return; }
      ManualFixedUpdate();
    }

    public void ManualFixedUpdate() {
      previousCollisionState = currentCollisionState;
      currentCollisionState = new CollisionState();

      float dt = Time.fixedDeltaTime;
      velocity.y += G * dt;
      Vector2 wantsToMoveAmount = (velocity * dt);
      Vector2 moveAmount = Move(wantsToMoveAmount);
      rigidbody.position += moveAmount;
      //transform.position += new Vector3(moveAmount.x, moveAmount.y);
      //Physics2D.SyncTransforms();

      FixVerticalVelocity();
      FixHorizontalVelocity();
    }

    void FixVerticalVelocity() {
      if (
        (currentCollisionState[Direction4.Down] && velocity.y < 0f) ||
        (currentCollisionState[Direction4.Up] && velocity.y > 0f)
      ) {
        velocity.y = 0f;
      }
    }

    void FixHorizontalVelocity() {
      if (
        (currentCollisionState[Direction4.Left] && velocity.x < 0f) ||
        (currentCollisionState[Direction4.Right] && velocity.x > 0f)
      ) {
        velocity.x = 0f;
      }
    }

    protected float CheckCollisionsForMovement(Vector2 position, float wantsToMoveAmount, Direction4 direction) {
      float skinWidth = 0;// Raycaster.skinWidth;
      float allowedMoveAmount = wantsToMoveAmount + skinWidth;
      RaycastHit2D[] hits = new RaycastHit2D[0];// raycaster.GetRaycastHits(position, allowedMoveAmount, direction);
      HashSet<ICollidable> collidedWith = new HashSet<ICollidable>();

      for(int i = 0; i < hits.Length; i++) {
        RaycastHit2D hit = hits[i];
        if (!hit || !hit.collider) {
          continue;
        }

        ICollidable collidable = hit.transform.GetComponent<ICollidable>();
        if (collidable != null) {
          if (collidedWith.Contains(collidable)) {
            continue;
          }
          collidedWith.Add(collidable);
          float collideDistance = Mathf.Max(0, allowedMoveAmount - hit.distance);
          float allowedCollideDistance = collidable.GetAllowedMoveInto(transform, collideDistance, direction, hit.point);
          float allowedDistance = allowedCollideDistance + hit.distance;
          if (allowedDistance < allowedMoveAmount) {
            allowedMoveAmount = allowedDistance;
            currentCollisionState[direction] = true;
          }
        } else {
          allowedMoveAmount = hit.distance;
          currentCollisionState[direction] = true;
        }
      }
      float finalDistance = Mathf.Clamp(allowedMoveAmount - skinWidth, 0, wantsToMoveAmount);
      return finalDistance;
    }
  }
}