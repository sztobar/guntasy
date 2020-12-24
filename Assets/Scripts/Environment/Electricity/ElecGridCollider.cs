using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using Player;
using Enums;

namespace Environment.Electricity {
  public class ElecGridCollider : MonoBehaviour {

    [SerializeField]
    private float damage;

    [SerializeField]
    new TilemapCollider2D collider;

    private static readonly RaycastHit2D[] results = new RaycastHit2D[1];

    public void ColliderDisable() {
      collider.enabled = false;
    }

    public void ColliderEnable() {
      collider.enabled = true;
    }

    private void FixedUpdate() {
      CheckCollisions();
    }

    private void CheckCollisions() {
      int count = collider.Cast(Vector2.zero, results);
      if (count > 0) {
        PlayerCollisionHandler playerCollisionHandler = results[0].transform.GetComponent<PlayerCollisionHandler>();
        playerCollisionHandler.TakeDamage(damage, DamageType.Electricity);
      }
    }

  }
}