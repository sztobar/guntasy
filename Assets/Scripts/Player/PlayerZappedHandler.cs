using UnityEngine;
using Kite;

public class PlayerZappedHandler : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  [Tooltip("Duration of player stop when zapped")]
  private float stopDuration;

  private PlayerPhysicsComponent physics;

  private float zapTimeLeft;

  public void Inject(PlayerDI di) {
    physics = di.Physics;
  }

  public void Zap() {
    physics.Velocity.X = 0;
    zapTimeLeft = stopDuration;
  }

  public bool IsZapped() {
    return zapTimeLeft > 0;
  }

  private void Update() {
    if (zapTimeLeft > 0) {
      zapTimeLeft -= Time.deltaTime;
    }
  }
}
