using UnityEngine;

public class WeaponEventSMB : BaseWeaponSMB {

  [SerializeField]
  private WeaponEvent startEvent;

  [SerializeField]
  [Tooltip("When animation ended")]
  private WeaponEvent endEvent;

  [SerializeField]
  [Tooltip("When animation was interrupted")]
  private WeaponEvent interruptedEvent;

  private WeaponStateMachine stateMachine;

  public override void Inject(IWeaponDI di) {
    stateMachine = di.StateMachine;
  }

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateEnter(animator, stateInfo, layerIndex);
    stateMachine.EmitEvent(startEvent);
  }

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateExit(animator, stateInfo, layerIndex);
    if (stateInfo.normalizedTime >= 1) {
      Debug.Log($"[WeaponEventSMB] EmitEvent={endEvent}");
      stateMachine.EmitEvent(endEvent);
    } else {
      Debug.Log($"[WeaponEventSMB] EmitEvent={interruptedEvent}");
      stateMachine.EmitEvent(interruptedEvent);
    }
  }
}
