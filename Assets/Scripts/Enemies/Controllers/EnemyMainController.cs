using UnityEngine;
using Enemies.StateMachine;

namespace Enemies.Controllers {
  public class EnemyMainController : MonoBehaviour {

    [SerializeField]
    private EnemyStateMachine headStateMachine;

    [SerializeField]
    private EnemyStateMachine bodyStateMachine;

    [SerializeField]
    private EnemyDI depencyInjector;

    public EnemyDI DI => depencyInjector;

    private void Awake() {
      headStateMachine.Init(this);
      bodyStateMachine.Init(this);
      SetPatrol();
    }

    public void SetAttack() {
      headStateMachine.SetAttack();
      bodyStateMachine.SetAttack();
    }

    public void SetPatrol() {
      headStateMachine.SetPatrol();
      bodyStateMachine.SetPatrol();
    }
  }
}