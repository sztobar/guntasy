using UnityEngine;
using Kite;

//[RequireComponent(typeof(Rigidbody2D))]
public class ShellRotate : MonoBehaviour {

  private static readonly float FULL_ROTATION = 360;

  [SerializeField] private float minRotationsPerSecond;
  [SerializeField] private float maxRotationsPerSecond;

  [SerializeField] private float minTileVelocity;
  [SerializeField] private float maxTileVelocity;

  [SerializeField] private float minAngle;
  [SerializeField] private float maxAngle;

  [SerializeField]
  [Range(0, 1)]
  [Tooltip("Percentage to stay on map after stopped.")]
  private float chanceToStay = 0.2f;

  private new Rigidbody2D rigidbody2D;
  private bool stayAfterStopped;

  private float RotationSpeed => Random.Range(minRotationsPerSecond, maxRotationsPerSecond) * FULL_ROTATION;
  private Vector2 DirectionVector => Vector2Extensions.DegreeToVector2(Random.Range(minAngle, maxAngle));
  private float Velocity => Random.Range(minTileVelocity, maxTileVelocity) * TileHelpers.TILE_SIZE;

  private void Awake() {
    if (chanceToStay >= Random.value) {
      stayAfterStopped = true;
    }
    rigidbody2D = GetComponent<Rigidbody2D>();
    rigidbody2D.angularVelocity = RotationSpeed;
    Vector2 rotation = new Vector2(Mathf.Sign(transform.right.x), 1);
    Vector2 direction = DirectionVector;
    rigidbody2D.velocity = rotation * direction * Velocity;
    //Debug.Log(direction);
  }

  private void Update() {
    if (rigidbody2D.velocity.magnitude <= 0.01) {
      if (stayAfterStopped) {
        enabled = false;
        Destroy(rigidbody2D);
      } else {
        Destroy(gameObject);
      }
    }
  }
}
