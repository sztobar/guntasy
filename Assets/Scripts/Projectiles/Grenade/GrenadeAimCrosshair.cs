using UnityEngine;
using System.Collections;

public class GrenadeAimCrosshair : MonoBehaviour {

  [SerializeField]
  [Range(0, 1)]
  private float showAtPercentage;

  public float Percentage => showAtPercentage;

  public void SetPosition(Vector2 position, Quaternion rotation) {
    Vector2 viewportPosition = CameraManager.MainCamera.WorldToViewportPoint(position);
    Vector2 pixelViewportPosition = CameraManager.Instance.ViewportToPixels(viewportPosition);
    transform.localPosition = pixelViewportPosition;
    transform.rotation = rotation;
  }
}
