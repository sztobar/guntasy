using UnityEngine;

public class ReloadCursor : MonoBehaviour {

  private static readonly int FULL_ROTATION = 360;

  [SerializeField] private Sprite reloadSprite;
  [SerializeField] private float reloadRotationsPerSecond;

  private bool reloadOn;

  public Sprite Sprite => reloadSprite;

  public void StartReload() {
    reloadOn = true;
  }

  public void StopReload() {
    reloadOn = false;
    transform.rotation = Quaternion.identity;
  }

  private void Update() {
    if (reloadOn) {
      transform.rotation *= Quaternion.Euler(0, 0, reloadRotationsPerSecond * FULL_ROTATION * Time.deltaTime);
    }
  }
}