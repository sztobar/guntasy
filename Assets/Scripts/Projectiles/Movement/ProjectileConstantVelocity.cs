using UnityEngine;
using Kite;

public class ProjectileConstantVelocity : BaseProjectileMovement {

  [SerializeField]
  private float tileVelocity;

  public override Vector2 GetVelocity() {
    return new Vector2(tileVelocity * TileHelpers.TILE_SIZE, 0);
  }
}
