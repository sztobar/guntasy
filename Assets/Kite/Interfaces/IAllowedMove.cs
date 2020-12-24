using UnityEngine;
using System.Collections;

namespace Kite {
  public interface IAllowedMove {
    Vector2 GetAllowedMovement(Vector2 position, Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    float GetAllowedMovement(Vector2 position, float distance, Direction4 direction);
  }
}