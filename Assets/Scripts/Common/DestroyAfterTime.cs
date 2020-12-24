using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

  [SerializeField]
  private float lifeTime;

  [SerializeField]
  [Tooltip("Optional")]
  private EmitDestructionItem emitDestructionItem;

  private float timeElapsed;

  private void Update() {
    if (timeElapsed < lifeTime) {
      timeElapsed += Time.deltaTime;
      if (timeElapsed >= lifeTime) {
        if (emitDestructionItem) {
          emitDestructionItem.DestroyGameObject();
        } else {
          Destroy(gameObject);
        }
      }
    }
  }
}
