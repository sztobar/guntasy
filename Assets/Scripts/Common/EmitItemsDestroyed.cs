using UnityEngine;
using System.Collections;
using System;

public class EmitItemsDestroyed : MonoBehaviour {

  [SerializeField]
  protected EmitDestructionItem[] items;

  protected int aliveLeft;

  public Action OnAllItemsDestroyed { get; set; } = delegate { };

  protected virtual void Awake() {
    aliveLeft = items.Length;
    for (int i = 0; i < items.Length; i++) {
      EmitDestructionItem item = items[i];
      OnItemInit(item, i);
    }
  }

  protected virtual void OnItemInit(EmitDestructionItem projectile, int i) {
    projectile.OnItemDestroy += HandleItemDestroyed;
  }

  private void HandleItemDestroyed() {
    aliveLeft--;
    if (aliveLeft == 0) {
      OnAllItemsDestroyed();
      Destroy(gameObject);
    }
  }
}
