using UnityEngine;

public enum CollisionType {
  Tile,
  Character,
  Projectile,
  Explosion,
  Unkown
}

public static class CollisionTypeExtensions {

  public static CollisionType FromRaycastHit2D(RaycastHit2D hit) {
    int layer = GetLayer(hit);
    return FromLayer(layer);
  }

  public static CollisionType FromLayer(int layer) {
    switch (layer) {
      case UnityConstants.Layers.Collision:
        return CollisionType.Tile;
      case UnityConstants.Layers.Enemy:
        return CollisionType.Character;
      case UnityConstants.Layers.Player_Projectile:
      case UnityConstants.Layers.EnemyProjectile:
        return CollisionType.Projectile;
      case UnityConstants.Layers.Explosion:
        return CollisionType.Explosion;
    }
    return CollisionType.Unkown;
  }

  private static int GetLayer(RaycastHit2D hit) {
    return hit.transform.gameObject.layer;
  }
}