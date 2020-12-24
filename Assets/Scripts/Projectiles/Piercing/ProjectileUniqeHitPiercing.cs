using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileUniqeHitPiercing : BaseProjectilePiercing {

  private readonly HashSet<Transform> piercedTargets = new HashSet<Transform>();

  public override bool CanHit(RaycastHit2D hit) {
    return !piercedTargets.Contains(hit.transform);
  }

  public override void PerformHit(RaycastHit2D hit) {
    piercedTargets.Add(hit.transform);
  }

  public override bool ShouldBeDestroyed() {
    return false;
  }
}
