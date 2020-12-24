using UnityEngine;
using System.Collections;

namespace Kite {
  public class DefaultCollidable : ICollidable {

    private static readonly DefaultCollidable _instance = new DefaultCollidable();

    public static DefaultCollidable Get() =>
      _instance;

    void ICollidable.ForceMoveInto(Transform moving, float collideDistance, Direction4 direction) { }

    float ICollidable.GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) =>
      0;
  }
}