using UnityEngine;

namespace Kite {
  public class GridPlatformCollidable : MonoBehaviour, ICollidable {

    float ICollidable.GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) {
      return PlatformCollidableHelpers.GetGridAllowedMovementInto(wantsToMove, collideDistance, direction, hitPoint);
    }

    void ICollidable.ForceMoveInto(Transform moving, float collideDistance, Direction4 direction) { }
  }
}