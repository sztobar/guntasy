using UnityEngine;
using System.Collections;

public class ConstantInaccuracyHandler : BaseInaccuracyHandler {

  [SerializeField]
  private float angle;

  public override void GenerateInaccuracy() {
    Inaccuracy = Quaternion.Euler(0, 0, GenerateInaccuracy(angle));
  }

  public override void Inject(IWeaponDI di) {
  }

  public override void PerformFire() {
  }
}
