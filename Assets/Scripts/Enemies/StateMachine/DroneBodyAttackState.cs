using UnityEngine;
using System.Collections;
using Enemies.Components;
using Enemies.Controllers;
using Kite;

namespace Enemies.StateMachine {
  public class DroneBodyAttackState : EnemyState {

    [SerializeField]
    private float chaseTileVelocity;

    [SerializeField]
    [Range(0, 1f)]
    private float velocitySmoothTime;

    [SerializeField]
    private float tileDistanceToChase;

    [SerializeField]
    private FloatyFloatComponent floatyFloat;

    private float velocityRef;

    private EnemyTargetDetectorComponent targetDetector;
    private OldPhysicsComponent physics;

    public override void Init(EnemyMainController controller) {
      base.Init(controller);
      targetDetector = controller.DI.targetDetectorComponent;
      physics = controller.DI.physicsComponent;
    }

    public override void UpdateState() {
      if (!CloseToTarget()) {
        float directionToTarget = Mathf.Sign(targetDetector.TargetPosition.x - controller.transform.position.x);
        float targetVelocity = chaseTileVelocity * TileHelpers.TILE_SIZE * directionToTarget;
        float velocityX = Mathf.SmoothDamp(physics.Velocity.x, targetVelocity, ref velocityRef, velocitySmoothTime);
        physics.SetVelocityX(velocityX);
      } else {
        physics.SetVelocityX(0);
      }
      physics.SetVelocityY(floatyFloat.GetFloatyFloatValue());
    }

    private bool CloseToTarget() {
      float dist = Vector2.Distance(transform.position, targetDetector.TargetPosition);
      return dist < (tileDistanceToChase * TileHelpers.TILE_SIZE);
    }
  }
}