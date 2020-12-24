using UnityEngine;
using System.Collections;
using Enemies.Components;
using Kite;

namespace Enemies.StateMachine {
  public class DroneBodyPatrolState : BodyPatrolState {

    [SerializeField]
    private FloatyFloatComponent floatyFloat;

    [SerializeField]
    private HorizontalFlipComponent directionComponent;

    protected override void MovementUpdate() {
      base.MovementUpdate();
      directionComponent.Direction = Direction2Helpers.FromFloat(physics.Velocity.x);
      physics.SetVelocityY(floatyFloat.GetFloatyFloatValue());
    }

    protected override bool CanWalk() {
      return !HitAWall();
    }

  }
}