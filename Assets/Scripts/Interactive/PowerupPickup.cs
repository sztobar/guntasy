using UnityEngine;
using Enums;
using Player;
using System;

namespace Interactive {
  public class PowerupPickup : BasePickup {

    private static readonly int STATE_HASH = Animator.StringToHash("State");

    [SerializeField]
    private PlayerPowerup powerupType;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    PowerupHint hint;

    private bool pickupTaken;

    public PlayerPowerup Type => powerupType;

    private void Awake() {
      if (powerupType == PlayerPowerup.Dash) {
        animator.SetInteger(STATE_HASH, (int)AnimState.Dash);
      } else {
        animator.SetInteger(STATE_HASH, (int)AnimState.DoubleJump);
      }
      hint.SetName(powerupType);
    }

    internal void PickupTaken() {
      animator.SetInteger(STATE_HASH, (int)AnimState.Off);
      pickupTaken = true;
      hint.gameObject.SetActive(false);
    }

    protected override void OnPlayerEnterCollision(PlayerCollisionHandler collisionHandler) {
      if (pickupTaken) {
        hint.gameObject.SetActive(false);
        return;
      }
      hint.gameObject.SetActive(true);
      collisionHandler.CollidingPowerupPickup = this;
    }

    protected override void OnPlayerExitCollision(PlayerCollisionHandler collisionHandler) {
      hint.gameObject.SetActive(false);
      collisionHandler.CollidingPowerupPickup = null;
    }

    enum AnimState {
      Off = 1,
      DoubleJump = 2,
      Dash = 3,
    }
  }
}