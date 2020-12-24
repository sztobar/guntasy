using UnityEngine;
using Cinemachine;
using Kite;

namespace EncounterRoom {
  public class EncounterRoom : MonoBehaviour {

    [SerializeField]
    private EncounterRoomDoor[] doors;

    [SerializeField]
    private EncounterRoomSpawner spawner;

    [SerializeField]
    private CompositeCollider2D roomBoundingShape;

    [SerializeField]
    private BaseCollider enterRoomCollider;

    [SerializeField]
    private CinemachineVirtualCamera roomCamera;

    [SerializeField]
    private AudioClip doorCloseSound;

    [SerializeField]
    private AudioClip doorOpenSound;

    private void Awake() {
      enterRoomCollider.OnCollision += OnPlayerEnterRoom;
      spawner.OnRoomComplete += OnEnemiesDefeated;
      spawner.Deactivate();
      roomCamera.Priority = 0;
    }

    private void OnPlayerEnterRoom(RaycastHit2D hit) {
      enterRoomCollider.ColliderDisable();
      foreach(var door in doors) {
        door.CloseDoor();
      }
      roomCamera.Priority = 100;
      spawner.Activate();
      AudioSingleton.PlaySound(doorCloseSound);
    }

    void OnEnemiesDefeated() {
      foreach (var door in doors) {
        door.OpenDoor();
      }
      roomCamera.Priority = 0;
      AudioSingleton.PlaySound(doorOpenSound);
    }
  }
}