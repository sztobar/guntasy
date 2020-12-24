using UnityEngine;
using System.Collections.Generic;

public class PushablesInRaycastHits {

  private readonly HashSet<Collider2D> pushTargetsSet = new HashSet<Collider2D>();

  public void Clear() {
    pushTargetsSet.Clear();
  }

  public IEnumerable<(RaycastHit2D, PushableComponent)> GetUnique(RaycastHit2D[] results) {
    for (int i = 0; i < results.Length; i++) {
      Collider2D target = results[i].collider;
      if (!target || pushTargetsSet.Contains(target)) {
        continue;
      }
      pushTargetsSet.Add(target);
      PushableComponent listener = target.GetComponent<PushableComponent>();
      if (!listener) {
        continue;
      }
      yield return (results[i], listener);
    }
  }
}
