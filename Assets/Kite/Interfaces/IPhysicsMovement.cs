using UnityEngine;

namespace Kite {
  public interface IPhysicsMovement {

    Bounds Bounds { get; }
    Vector2 Position { get; set; }

    Vector2 GetAllowedMovement(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    float GetAllowedMovement(float distance, Direction4 direction);

    void ForceMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    void ForceMove(float distance, Direction4 direction);

    Vector2 TryToMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    float TryToMove(float distance, Direction4 direction);
  }
}