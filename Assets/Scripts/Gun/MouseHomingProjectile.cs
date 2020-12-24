using UnityEngine;
using UnityEngine.InputSystem;
using Kite;

namespace Gun {
  public class MouseHomingProjectile : MonoBehaviour {

    [SerializeField]
    private float velocity;

    [SerializeField]
    private Direction4 spriteDirection;

    private Vector2 mouseAbsolutePosition;

    private void FixedUpdate() {
      transform.Translate(spriteDirection.ToVector3(velocity * Time.fixedDeltaTime));
    }

    private void Update() {
      mouseAbsolutePosition = Mouse.current.position.ReadValue();
      Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mouseAbsolutePosition);
      Vector2 playerPosition = transform.position;
      Vector2 aim = worldMousePosition - playerPosition;

      Quaternion rotation = Quaternion.LookRotation(Vector3.forward, aim);

      transform.rotation = rotation;
    }
  }
}