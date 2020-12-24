using UnityEngine;

public class MeasureReloadTime : BaseWeaponSMB {

  private IWeaponAmmoHandler ammoHandler;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateEnter(animator, stateInfo, layerIndex);
    ammoHandler.SetReloadPercentage(0);
  }

  public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateUpdate(animator, stateInfo, layerIndex);
    ammoHandler.SetReloadPercentage(stateInfo.normalizedTime);
  }

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateExit(animator, stateInfo, layerIndex);
    ammoHandler.SetReloadPercentage(0);
  }

  public override void Inject(IWeaponDI di) {
    ammoHandler = di.AmmoHandler;
  }
}
