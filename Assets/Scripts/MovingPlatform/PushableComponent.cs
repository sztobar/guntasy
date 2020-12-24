using UnityEngine;
using Kite;

public class PushableComponent : MonoBehaviour {

  [SerializeField] private PhysicsMovement movement;

  public Vector2 Push(Vector2 move, MoveMode mode = MoveMode.HorizontalFirst) {
    return movement.TryToMove(move, mode);
  }
}
