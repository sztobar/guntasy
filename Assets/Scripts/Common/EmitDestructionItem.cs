using UnityEngine;
using System;

public class EmitDestructionItem : MonoBehaviour {

  public Action OnItemDestroy { get; set; } = delegate { };
  private bool destroyed;
  private float timeToDestroyLeft;

  public bool IsDestroyed => destroyed;

  public void DestroyGameObject() {
    if (!destroyed) {
      OnItemDestroy();
      Destroy(gameObject);
    }
    destroyed = true;
  }

  internal void DestroyGameObjectAfter(float timeToDestroy) {
    destroyed = true;
    timeToDestroyLeft = timeToDestroy;
  }

  private void Update() {
    if (timeToDestroyLeft > 0) {
      timeToDestroyLeft -= Time.deltaTime;
      if (timeToDestroyLeft <= 0) {
        OnItemDestroy();
        Destroy(gameObject);
      }
    }
  }
}
