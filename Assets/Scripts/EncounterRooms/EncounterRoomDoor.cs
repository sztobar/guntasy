using UnityEngine;

namespace EncounterRoom {
  public class EncounterRoomDoor : MonoBehaviour {

    [SerializeField]
    private Collider2D roomCollider;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private bool opened;

    private void Awake() {
      if (opened) {
        OpenDoor();
      } else {
        CloseDoor();
      }
    }

    internal void CloseDoor() {
      opened = false;
      roomCollider.enabled = true;
      spriteRenderer.enabled = true;
    }

    internal void OpenDoor() {
      opened = true;
      roomCollider.enabled = false;
      spriteRenderer.enabled = false;
    }
  }
}