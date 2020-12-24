using UnityEngine;

public class BigExplosionDamage : ExplosionDamage {

  [SerializeField]
  private ExplosionDamage[] explosionPieces;

  public override void SetDamage(float newDamage) {
    base.SetDamage(newDamage);
    foreach (var piece in explosionPieces) {
      piece.SetDamage(newDamage);
    }
  }
}
