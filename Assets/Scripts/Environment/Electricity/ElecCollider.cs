using UnityEngine;
using System.Collections;
using System;
using Common;
using Player;
using Enums;

namespace Environment.Electricity {
  public class ElecCollider : MonoBehaviour {

    [SerializeField]
    private float damage;

    [SerializeField]
    ElecAnimator animator;

    [SerializeField]
    private BaseCollider baseCollider;


    private void Awake() {
      animator.CurrentOn();
      baseCollider.OnCollision += HandlePlayerCollision;
    }

    private void HandlePlayerCollision(RaycastHit2D hit) {
      PlayerCollisionHandler playerCollisionHandler = hit.transform.GetComponent<PlayerCollisionHandler>();
      playerCollisionHandler.TakeDamage(damage, DamageType.Electricity);
    }

    public void CurrentOn() {
      gameObject.SetActive(true);
      animator.CurrentOn();
    }

    public void CurrentOff() {
      gameObject.SetActive(false);
    }
  }
}