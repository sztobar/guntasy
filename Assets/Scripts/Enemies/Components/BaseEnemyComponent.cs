using UnityEngine;
using System.Collections;

namespace Enemies.Components {
  public abstract class BaseEnemyComponent : MonoBehaviour {

    public abstract void EnemyFixedAwake();
    public abstract void EnemyFixedUpdate();
  }
}