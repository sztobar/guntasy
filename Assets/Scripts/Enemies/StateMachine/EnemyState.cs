using UnityEngine;
using System.Collections;
using Kite;
using Enemies.Controllers;

namespace Enemies.StateMachine {
  public abstract class EnemyState : MonoBehaviour, IState {

    protected EnemyMainController controller;

    public virtual void Init(EnemyMainController controller) {
      this.controller = controller;
    }

    public virtual void ExitState() { }

    public virtual void StartState() { }

    public abstract void UpdateState();
  }
}