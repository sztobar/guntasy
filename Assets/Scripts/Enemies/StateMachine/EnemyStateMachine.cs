using UnityEngine;
using Enemies.Controllers;
using Kite;

namespace Enemies.StateMachine {
  public class EnemyStateMachine : MonoBehaviour {

    [SerializeField]
    private EnemyState patrol;

    [SerializeField]
    private EnemyState attack;

    private Kite.StateMachine stateMachine = new Kite.StateMachine();

    public void Init(EnemyMainController controller) {
      patrol.Init(controller);
      attack.Init(controller);
      SetPatrol();
    }

    public void SetAttack() {
      stateMachine.TransitionToState(attack);
    }

    public void SetPatrol() {
      stateMachine.TransitionToState(patrol);
    }

    private void FixedUpdate() {
      stateMachine.UpdateState();
    }
  }
}