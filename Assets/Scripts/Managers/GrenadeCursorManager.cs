using UnityEngine;

public class GrenadeCursorManager : MonoBehaviour {

  public static GrenadeCursorManager Instance;

  [SerializeField]
  private GrenadeAimCrosshair[] grenadeCrosshairs;

  void Awake() {
    if (!Instance) {
      Instance = this;
      Deactivate();
    } else {
      Destroy(gameObject);
    }
  }

  public GrenadeAimCrosshair[] GrenadeCrossHairs() {
    return grenadeCrosshairs;
  }

  public void Activate() {
    gameObject.SetActive(true);
  }

  public void Deactivate() {
    gameObject.SetActive(false);
  }
}
