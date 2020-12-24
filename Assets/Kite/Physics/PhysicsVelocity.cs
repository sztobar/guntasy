using UnityEngine;

namespace Kite {
  public class PhysicsVelocity : MonoBehaviour {

    private static readonly float MIN_COLLISION_MAGNITUDE = 0.01f;

    private CollisionState collision;
    private Vector2 velocity;

    public CollisionState CurrentCollision => collision;

    public Vector2 Value {
      get => velocity;
      set => velocity = value;
    }

    public float X {
      get => velocity.x;
      set => velocity.x = value;
    }

    public float Y {
      get => velocity.y;
      set => velocity.y = value;
    }

    public Vector2 deltaPosition => velocity * Time.deltaTime;

    public void ResolveCollision(Vector2 moveAmount) {
      collision = new CollisionState();
      Vector2 effectiveVelocity = moveAmount / Time.deltaTime;
      if (Mathf.Abs(effectiveVelocity.x - velocity.x) >= MIN_COLLISION_MAGNITUDE) {
        collision[velocity.ToDirection4Horizontal()] = true;
        velocity.x = effectiveVelocity.x;
      }
      if (Mathf.Abs(effectiveVelocity.y - velocity.y) >= MIN_COLLISION_MAGNITUDE) {
        collision[velocity.ToDirection4Vertical()] = true;
        velocity.y = effectiveVelocity.y;
      }
    }
  }
}