using UnityEngine;

public class ProjectileNoPiercing : BaseProjectilePiercing {

  public override bool CanHit(RaycastHit2D hit) {
    return true;
  }

  public override void PerformHit(RaycastHit2D hit) { }

  public override bool ShouldBeDestroyed() {
    return true;
  }
}
