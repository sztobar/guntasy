using UnityEngine;
using System.Collections;

public class RecoilBasedOnInaccuracy : BaseWeaponRecoil {

  [SerializeField]
  private float recoilScale = 1;

  [SerializeField]
  private float recoilTime;

  private IInaccuracyHandler inaccuracyHandler;

  private Quaternion afterFireRecoil;
  private float recoilTimeLeft;

  public override void Inject(IWeaponDI di) {
    inaccuracyHandler = di.InaccuracyHandler;
  }

  public override void PerformFire() {
    Quaternion inaccuracy = inaccuracyHandler.Inaccuracy;
    afterFireRecoil = Quaternion.Euler(inaccuracy.eulerAngles * recoilScale);
    recoilTimeLeft = recoilTime;
  }

  private void Update() {
    if (recoilTimeLeft > 0) {
      recoilTimeLeft = Mathf.Max(recoilTimeLeft - Time.deltaTime, 0);
      Recoil = Quaternion.Slerp(Quaternion.identity, afterFireRecoil, recoilTimeLeft / recoilTime);
    }
  }
}
