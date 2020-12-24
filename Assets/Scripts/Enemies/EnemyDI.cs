using UnityEngine;
using Enemies.Components;
using Kite;

namespace Enemies {
  public class EnemyDI : MonoBehaviour {

    public EnemyTargetDetectorComponent targetDetectorComponent;
    public EnemyShootComponent shootComponent;
    public OldPhysicsComponent physicsComponent;
    public HorizontalFlipComponent directionComponent;

  }
}