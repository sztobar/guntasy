using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraManager : MonoBehaviour {

  public static CameraManager Instance { get; private set; }
  public static Camera MainCamera => Instance.camera;

  [SerializeField]
  private new Camera camera;

  [SerializeField]
  private PixelPerfectCamera pixelPerfectCamera;

  private void Awake() {
    if (!Instance) {
      Instance = this;
    } else {
      Destroy(gameObject);
    }
  }

  public Vector2 ViewportToPixels(Vector2 viewportPosition) {
    float localViewportX = Mathf.Clamp01(viewportPosition.x) - 0.5f;
    float localViewportY = Mathf.Clamp01(viewportPosition.y) - 0.5f;

    int pixelRatio = pixelPerfectCamera.pixelRatio;
    float originalPixelWidth = camera.pixelWidth / pixelRatio;
    float originalPixelHeight = camera.pixelHeight / pixelRatio;

    Vector2 pixelViewportPosition = new Vector2(
      localViewportX * originalPixelWidth,
      localViewportY * originalPixelHeight
    );
    return pixelViewportPosition;
  }
}
