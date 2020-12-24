using UnityEngine;
using System.Collections;
using Enemies.Components;
using Enemies.Controllers;

namespace Enemies.StateMachine {
  public class HeadPatrolState : EnemyState {

    private EnemyTargetDetectorComponent targetDetectorComponent;
    private EnemyShootComponent shootComponent;

    public override void Init(EnemyMainController controller) {
      base.Init(controller);
      targetDetectorComponent = controller.DI.targetDetectorComponent;
      shootComponent = controller.DI.shootComponent;
    }

    public override void StartState() {
      base.StartState();
      shootComponent.ResetAim();
    }

    public override void UpdateState() {
      if (targetDetectorComponent.HasTarget()) {
        controller.SetAttack();
      }
    }
  }
}