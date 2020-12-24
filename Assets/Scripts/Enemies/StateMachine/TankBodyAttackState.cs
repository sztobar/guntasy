using UnityEngine;
using Enemies.Controllers;
using Enemies.Components;
using Kite;

namespace Enemies.StateMachine {
  public class TankBodyAttackState : EnemyState {

    [SerializeField]
    private float chaseTileVelocity;

    [SerializeField]
    [Range(0, 1f)]
    private float velocitySmoothTime;

    [SerializeField]
    private TankBodyAnimator animator;

    private float velocityRef;

    private EnemyTargetDetectorComponent targetDetector;
    private OldPhysicsComponent physics;

    public override void Init(EnemyMainController controller) {
      base.Init(controller);
      targetDetector = controller.DI.targetDetectorComponent;
      physics = controller.DI.physicsComponent;
    }

    public override void UpdateState() {
      float directionToTarget = Mathf.Sign(targetDetector.TargetPosition.x - controller.transform.position.x);
      if (ReachesEdgeInDirection(directionToTarget)) {
        physics.SetVelocityX(0);
        animator.UpdateAnimationSpeed(0);
      } else {
        float targetVelocity = chaseTileVelocity * TileHelpers.TILE_SIZE * directionToTarget;
        float velocityX = Mathf.SmoothDamp(physics.Velocity.x, targetVelocity, ref velocityRef, velocitySmoothTime);
        physics.SetVelocityX(velocityX);
        animator.UpdateAnimationSpeed(velocityX);
      }
    }

    private bool ReachesEdgeInDirection(float directionValue) {
      Direction2H direction = Direction2Helpers.FromFloat(directionValue);
      return physics.ReachedEdge(direction, 1);
    }
  }
}