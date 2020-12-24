using UnityEngine;
using System.Collections;

public class ConstantRecoil : BaseWeaponRecoil {

  [SerializeField]
  private float recoilPerFire;

  [SerializeField]
  private float recoilTime;

  private Quaternion afterFireRecoil;
  private float recoilTimeLeft;


  public override void Inject(IWeaponDI di) {
  }

  public override void PerformFire() {
    afterFireRecoil = Quaternion.Euler(0, 0, recoilPerFire);
    recoilTimeLeft = recoilTime;
  }

  private void Update() {
    if (recoilTimeLeft > 0) {
      recoilTimeLeft = Mathf.Max(recoilTimeLeft - Time.deltaTime, 0);
      Recoil = Quaternion.Slerp(Quaternion.identity, afterFireRecoil, recoilTimeLeft / recoilTime);
    }
  }
}
