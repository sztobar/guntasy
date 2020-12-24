using UnityEngine;
using System.Collections;

public interface ICollisionHandler {
  /// <summary>
  /// Collision with a tileset
  /// </summary>
  /// <param name="hit"></param>
  void HandleTileCollision(RaycastHit2D hit);

  /// <summary>
  /// Collision with Enemy or Player
  /// </summary>
  /// <param name="hit"></param>
  void HandleCharacterCollision(RaycastHit2D hit);
  
  /// <summary>
  /// Collision with another projectile
  /// </summary>
  /// <param name="hit"></param>
  void HandleProjectileCollision(RaycastHit2D hit);

  /// <summary>
  /// Collision with explosion
  /// </summary>
  /// <param name="hit"></param>
  void HandleExplosionCollision(RaycastHit2D hit);

}
