using UnityEngine;
using Kite;

public class DestroyOutOfCamera : MonoBehaviour {

  [SerializeField]
  private float cameraBoundsScale = 1f;

  [SerializeField]
  private new Collider2D collider;

  [SerializeField]
  [Tooltip("Optional")]
  private EmitDestructionItem emitDestructionItem;

  private new Camera camera;

  private void Awake() {
    camera = Camera.main;
  }

  private void Update() {
    if (camera.IsOutOfSight(collider.bounds, cameraBoundsScale)) {
      if (emitDestructionItem) {
        emitDestructionItem.DestroyGameObject();
      } else {
        Destroy(gameObject);
      }
    }
  }
  
}
