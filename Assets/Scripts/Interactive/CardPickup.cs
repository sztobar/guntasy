using Player;
using Managers;
using Enums;
using UnityEngine;

namespace Interactive {
  public class CardPickup : BasePickup {

    [SerializeField]
    private CollectCards type;

    private void Awake() {
    }

    protected override void OnPlayerEnterCollision(PlayerCollisionHandler collisionHandler) {
      CollectCardsManager.Instance.OnCardObtained(type);
      Destroy(gameObject);
    }

    protected override void OnPlayerExitCollision(PlayerCollisionHandler collisionHandler) {
    }
  }
}