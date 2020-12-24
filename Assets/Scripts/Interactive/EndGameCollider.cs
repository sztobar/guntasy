using UnityEngine;
using System.Collections;
using Player;
using Managers;

namespace Interactive {

  public class EndGameCollider : BasePickup {
    public object GameplayerManager { get; private set; }

    protected override void OnPlayerEnterCollision(PlayerCollisionHandler collisionHandler) {
      GameplayManager.Instance.GoToCredits();
    }

    protected override void OnPlayerExitCollision(PlayerCollisionHandler collisionHandler) {
    }
  }
}
