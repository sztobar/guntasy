using UnityEngine;
using Enums;
using System.Collections;
using Player;

namespace Interactive {
  public class HealthPickup : MonoBehaviour {

    [SerializeField]
    private float healAmount;

    [SerializeField]
    private new BoxCollider2D collider;

    private static readonly RaycastHit2D[] results = new RaycastHit2D[1];

    private void FixedUpdate() {
      if (CollidesWithPlayer()) {
        
        var playerCollisionHandler = results[0].transform.GetComponent<PlayerCollisionHandler>();
        bool isPickedUp = playerCollisionHandler.HealPlayer(this.healAmount);
        if (isPickedUp)
        {
            Destroy(gameObject);
        }
      }
    }

    private bool CollidesWithPlayer() {
      int count = collider.Cast(Vector2.zero, results);
      return count > 0;
    }
  }
}