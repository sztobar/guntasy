using UnityEngine;
using System.Collections;

namespace Kite {
  public abstract class PhysicsMovement : MonoBehaviour {

    public abstract Bounds Bounds { get; }

    public abstract Vector2 GetAllowedMovement(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    public abstract float GetAllowedMovement(float distance, Direction4 direction);

    public abstract void ForceMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    public abstract void ForceMove(float distance, Direction4 direction);

    public abstract Vector2 TryToMove(Vector2 wantsToMoveAmount, MoveMode mode = MoveMode.HorizontalFirst);
    public abstract float TryToMove(float distance, Direction4 direction);
  }
}