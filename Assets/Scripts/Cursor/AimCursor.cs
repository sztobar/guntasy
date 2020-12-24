using UnityEngine;
using UnityEngine.UI;

public class AimCursor : MonoBehaviour {
  
  [SerializeField] private Image uiImage;

  private void Start() {
    uiImage.SetNativeSize();
  }

  public void SetCursor(Sprite sprite) {
    uiImage.sprite = sprite;
    uiImage.color = sprite ? Color.white : new Color(0, 0, 0, 0);
    uiImage.SetNativeSize();
  }

  public void SetLocalPosition(Vector2 localPostion) {
    transform.localPosition = localPostion;
  }
}