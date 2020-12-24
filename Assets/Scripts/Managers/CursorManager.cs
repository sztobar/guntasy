using UnityEngine;

public class CursorManager : MonoBehaviour {

  public static CursorManager Instance;

  [SerializeField] private AimCursor aimCursor;
  [SerializeField] private GrenadeCursor grenadeCursor;
  [SerializeField] private ReloadCursor reloadCursor;
  [SerializeField] private CursorMode mode = CursorMode.Aim;
  [SerializeField, HideInInspector] private CursorConfiner cursorConfiner;

  public CursorConfiner CursorConfiner => cursorConfiner;
  public GrenadeCursor GrenadeCursor => grenadeCursor;
  public AimCursor AimCursor => aimCursor;

  void Awake() {
    if (!Instance) {
      Instance = this;
      cursorConfiner = new CursorConfiner();
    } else {
      Destroy(gameObject);
    }
  }

  public void SetWorldPosition(Vector2 position) {
    Vector2 viewportPosition = CameraManager.MainCamera.WorldToViewportPoint(position);
    Vector2 pixelViewportPosition = CameraManager.Instance.ViewportToPixels(viewportPosition);
    aimCursor.SetLocalPosition(pixelViewportPosition);
  }

  public void SetMode(CursorMode newMode) {
    reloadCursor.StopReload();
    mode = newMode;
    switch (mode) {
      case CursorMode.Aim:
        OnAimCursorMode();
        break;
      case CursorMode.Grenade:
        OnGrenadeCursorMode();
        break;
    }
  }

  private void OnGrenadeCursorMode() {
    grenadeCursor.gameObject.SetActive(true);
    aimCursor.gameObject.SetActive(false);
  }

  private void OnAimCursorMode() {
    grenadeCursor.gameObject.SetActive(false);
    aimCursor.gameObject.SetActive(true);
  }

  public void StartReload() {
    reloadCursor.StartReload();
    aimCursor.SetCursor(reloadCursor.Sprite);
    OnAimCursorMode();
  }

  public void StopReload() {
    reloadCursor.StopReload();
    if (mode == CursorMode.Grenade) {
      OnGrenadeCursorMode();
    }
  }

  public void ResetNativeCursor() {
    Cursor.visible = true;
  }

  public void HideNativeIfInsideViewport(Vector2 viewportPosition) {
    if (IsOutOf01(viewportPosition.x) || IsOutOf01(viewportPosition.y)) {
      Cursor.visible = true;
    } else {
      Cursor.visible = false;
    }
  }

  private bool IsOutOf01(float x) {
    return x < 0 || x > 1;
  }

  private void OnDisable() {
    ResetNativeCursor();
  }
}
