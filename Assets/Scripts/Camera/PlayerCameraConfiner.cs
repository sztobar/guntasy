using System;
using UnityEngine;
using Kite;

public class PlayerCameraConfiner : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  private ScalingConfiner confiner;

  [SerializeField]
  private Transform target;

  private PlayerInputHandler inputHandler;

  public void SetConfinerScale(float aimScale) {
    confiner.SetScale(aimScale);
  }

  public void ResetConfinerScale() {
    confiner.ResetScale();
  }

  private void Update() {
    TargetPositionUpdate();
  }

  private void TargetPositionUpdate() {
    Vector2 targetNewPosition = inputHandler.MousePixelViewportPosition;
    targetNewPosition = confiner.ClosestPoint(targetNewPosition);
    target.localPosition = targetNewPosition;
  }

  public void Inject(PlayerDI di) {
    inputHandler = di.Input;
  }
}
