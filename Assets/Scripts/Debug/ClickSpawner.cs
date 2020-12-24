using UnityEngine;
using UnityEngine.InputSystem;

public class ClickSpawner : MonoBehaviour {

  [SerializeField] private GameObject objectToSpawn;
  [SerializeField] private float clickDelay = 0.1f;

  private float delayLeft;

  private void Update() {
    var mouse = Mouse.current;
    if (mouse != null) {
      if (mouse.leftButton.wasPressedThisFrame && delayLeft <= 0) {
        var mousePos = mouse.position.ReadValue();
        var camera = Camera.main;
        Spawn(camera.ScreenToWorldPoint(mousePos));
        delayLeft = clickDelay;
        return;
      }
    }
    if (delayLeft > 0) {
      delayLeft -= Time.deltaTime;
    }
  }

  private void Spawn(Vector2 position) {
    var spawned = Instantiate(objectToSpawn, position, Quaternion.identity);
    spawned.SetActive(true);
  }
}
