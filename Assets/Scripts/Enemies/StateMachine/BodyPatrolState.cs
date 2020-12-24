using UnityEngine;
using Kite;
using Enemies.Controllers;

namespace Enemies.StateMachine {
  public class BodyPatrolState : EnemyState {

    [SerializeField]
    private float tileVelocity;

    [SerializeField]
    [Range(0, .3f)]
    public float movementSmoothing = .05f;

    [SerializeField]
    protected float pauseAfterTransiton = 0.5f;

    [SerializeField]
    Direction2H initialDirection = Direction2H.Left;

    private Direction2H direction;
    private float timeToBeginLeft;
    private float smoothDampVelocity;
    protected OldPhysicsComponent physics;
    //private IEnumerator stateCoroutine;

    public override void Init(EnemyMainController controller) {
      base.Init(controller);
      direction = initialDirection;
      physics = controller.DI.physicsComponent;
    }

    public override void StartState() {
      base.StartState();
      if (timeToBeginLeft > 0f) {
        physics.SetVelocityX(0);
        direction = Direction2Helpers.Random();
        //stateCoroutine = StartStateCoroutine();
        //StartCoroutine(stateCoroutine);
      }
    }

    public override void ExitState() {
      timeToBeginLeft = pauseAfterTransiton;
      base.ExitState();
      //if (stateCoroutine != null) {
      //  StopCoroutine(stateCoroutine);
      //  stateCoroutine = null;
      //}
    }

    public override void UpdateState() {
      if (timeToBeginLeft > 0) {
        timeToBeginLeft -= Time.deltaTime;
      } else {
        MovementUpdate();
      }
    }

    protected virtual void MovementUpdate() {
      if (CanWalk()) {
        VelocityUpdate();
      } else {
        direction = direction.Flip();
      }
    }

    void VelocityUpdate() {
      float targetVelocity = tileVelocity * TileHelpers.TILE_SIZE * direction.ToFloat();
      float velocityX = Mathf.SmoothDamp(physics.Velocity.x, targetVelocity, ref smoothDampVelocity, movementSmoothing);
      physics.SetVelocityX(velocityX);
    }


    protected virtual bool CanWalk() {
      return !(ReachedEdge() || HitAWall());
    }

    private bool ReachedEdge() {
      return physics.ReachedEdge(direction, 1f);
    }

    protected bool HitAWall() {
      return physics.CurrentCollisionState[direction];
    }

    //IEnumerator StartStateCoroutine() {
    //  physics.SetVelocityX(0);
    //  yield return new WaitForSeconds(timeToBeginLeft);
    //  timeToBeginLeft = 0;
    //}
  }
}