using UnityEngine;

namespace Kite {
  public interface ICollidable {

    float GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint);
    
    void ForceMoveInto(Transform moving, float collideDistance, Direction4 direction);
  }
}
