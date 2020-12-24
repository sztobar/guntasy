using UnityEngine;

public class AngularVelocity : MonoBehaviour {

  private static readonly float FULL_ROTATION = 360;

  [SerializeField]
  private float rotationsPerSecond;

  [SerializeField]
  private new Rigidbody2D rigidbody;

  public float RotationSpeed => -rotationsPerSecond * FULL_ROTATION * Mathf.Sign(transform.right.x);

  void Awake() {
    rigidbody.angularVelocity = RotationSpeed;
  }
}
