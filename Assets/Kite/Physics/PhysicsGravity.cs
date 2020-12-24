using UnityEngine;

namespace Kite {
  public class PhysicsGravity : MonoBehaviour {

    [SerializeField] private float gravityScale;
    [SerializeField] private float maxFallTileVelocity;
    [SerializeField] private PhysicsVelocity velocity;

    public float G => Physics2D.gravity.y * gravityScale * TileHelpers.TILE_SIZE;

    public float Scale {
      get => gravityScale;
      set => gravityScale = value;
    }

    private void FixedUpdate() {
      float velocityY = velocity.Y;
      float maxFallVelocity = -maxFallTileVelocity * TileHelpers.TILE_SIZE;
      if (velocityY > maxFallVelocity) {
        float dt = Time.deltaTime;
        float newVelocityY = velocityY + G * dt;
        velocity.Y = Mathf.Max(newVelocityY, maxFallVelocity);
      }
    }
  }
}