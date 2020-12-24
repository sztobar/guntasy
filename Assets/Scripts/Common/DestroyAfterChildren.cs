using System;
using UnityEngine;

public class DestroyAfterChildren : EmitDestructionItem {

  [SerializeField]
  protected EmitDestructionItem[] items;

  protected int aliveLeft;

  public void AddChild(EmitDestructionItem copy) {
    aliveLeft++;
    OnItemInit(copy);
  }

  public virtual void Awake() {
    aliveLeft = items.Length;
    for (int i = 0; i < items.Length; i++) {
      EmitDestructionItem item = items[i];
      OnItemInit(item);
    }
  }

  private void OnItemInit(EmitDestructionItem projectile) {
    projectile.OnItemDestroy += HandleItemDestroyed;
  }

  private void HandleItemDestroyed() {
    aliveLeft--;
    if (aliveLeft == 0) {
      DestroyGameObject();
    }
  }
}
