using UnityEngine;
using Cinemachine;
using Kite;

public class MovingPlatformController : MonoBehaviour {

  [SerializeField] private float tileVelocity;

  [SerializeField]
  [Tooltip("No effect for looped paths")]
  private float waitTimeAtEnds;

  [SerializeField] private CinemachinePathBase path;

  [SerializeField] private MovingPlatformCollidablesBase movingPhysics;

  [SerializeField] private Rigidbody2D rigidBody;

  [SerializeField] private bool pixelPerfectMove;

  private bool forward = true;
  private float pathProgress;
  private float waitTimeLeft;

  private float Velocity => tileVelocity * TileHelpers.TILE_SIZE;

  private void Start() {
    if (pixelPerfectMove) {
      rigidBody.position = PixelHelpers.Floor(rigidBody.position);
    }
  }


  private void FixedUpdate() {
    if (path.Looped) {
      LoopedPathUpdate();
    } else {
      PatrolUpdate();
    }
  }

  private void PatrolUpdate() {
    if (waitTimeLeft > 0) {
      PatrolWaitUpdate();
    } else {
      PatrolMovementUpdate();
    }
  }

  private void PatrolMovementUpdate() {
    float deltaPath = Velocity * Time.deltaTime;
    float pathLength = path.PathLength;
    pathProgress = Mathf.Min(pathProgress + deltaPath, pathLength);

    ApplyPathProgress(pathProgress, pathLength);

    if (pathProgress >= pathLength) {
      forward = !forward;
      pathProgress = 0;
      waitTimeLeft = waitTimeAtEnds;
    }
  }

  private void ApplyPathProgress(float pathProgress, float pathLength) {
    Vector2 previousPosition = rigidBody.position;
    float currentPathPosition = forward ? pathProgress : pathLength - pathProgress;
    Vector2 newPosition = path.EvaluatePositionAtUnit(currentPathPosition, CinemachinePathBase.PositionUnits.Distance);
    Vector2 deltaPosition = newPosition - previousPosition;

    if (pixelPerfectMove) {
      deltaPosition = PixelHelpers.Floor(deltaPosition);
    }
    if (deltaPosition != Vector2.zero) {
      movingPhysics.TransferMovement(deltaPosition);
      rigidBody.position += deltaPosition;
    }
  }

  private void PatrolWaitUpdate() {
    waitTimeLeft -= Time.deltaTime;
  }

  private void LoopedPathUpdate() {
    pathProgress += Velocity * Time.deltaTime;
    float pathLength = path.PathLength;
    if (pathProgress >= pathLength) {
      pathProgress -= pathLength;
    }
    ApplyPathProgress(pathProgress, pathLength);
  }

}
