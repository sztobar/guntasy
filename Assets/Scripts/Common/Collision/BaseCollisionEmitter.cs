using UnityEngine;
using System;

public abstract class BaseCollisionEmitter : MonoBehaviour {

  public Action<RaycastHit2D, CollisionType> OnCollision { get; set; } = delegate { };

  public abstract void Cast();

  protected void HandleCollision(RaycastHit2D hit) {
    CollisionType type = CollisionTypeExtensions.FromRaycastHit2D(hit);
    if (type != CollisionType.Unkown) {
      OnCollision(hit, type);
    }
  }
}
