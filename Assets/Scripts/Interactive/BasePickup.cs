using UnityEngine;
using System.Collections;
using Player;

public abstract class BasePickup : MonoBehaviour {

  [SerializeField]
  protected new BoxCollider2D collider;

  private bool wasCollidingWithPlayer;
  private PlayerCollisionHandler currentCollisionHandler;

  private static readonly RaycastHit2D[] results = new RaycastHit2D[1];

  protected abstract void OnPlayerEnterCollision(PlayerCollisionHandler collisionHandler);
  protected abstract void OnPlayerExitCollision(PlayerCollisionHandler collisionHandler);

  private void FixedUpdate() {
    bool currentlyCollidesWithPlayer = CollidesWithPlayer();

    if (!wasCollidingWithPlayer && currentlyCollidesWithPlayer) {
      currentCollisionHandler = results[0].collider.GetComponentInChildren<PlayerCollisionHandler>();
      OnPlayerEnterCollision(currentCollisionHandler);
    } else if (wasCollidingWithPlayer && !currentlyCollidesWithPlayer) {
      OnPlayerExitCollision(currentCollisionHandler);
      currentCollisionHandler = null;
    }
    wasCollidingWithPlayer = currentlyCollidesWithPlayer;
  }

  private bool CollidesWithPlayer() {
    int count = collider.Cast(Vector2.zero, results);
    return count > 0;
  }

}
