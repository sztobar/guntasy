using UnityEngine;
using System.Collections;
using Enemies.Components;
using Enemies.Controllers;

namespace Enemies.StateMachine {
  public class HeadAttackState : EnemyState {

    private EnemyTargetDetectorComponent targetDetectorComponent;
    private EnemyShootComponent shootComponent;

    public override void Init(EnemyMainController controller) {
      base.Init(controller);
      targetDetectorComponent = controller.DI.targetDetectorComponent;
      shootComponent = controller.DI.shootComponent;
    }

    public override void UpdateState() {
      if (!targetDetectorComponent.HasTarget()) {
        controller.SetPatrol();
      } else {
        shootComponent.AimAt(targetDetectorComponent.TargetPosition);
        shootComponent.Shoot();
      }
    }

    public override void ExitState() {
      base.ExitState();
      shootComponent.ResetAim();
    }
  }
}