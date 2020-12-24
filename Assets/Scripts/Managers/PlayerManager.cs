using Enums;
using Kite;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {
  public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;

    public float AmmoPercentage { get; set; }
    public float HpPercentage { get; set; }
    public float ArmorPercentage { get; set; }

    private HashSet<PlayerPowerup> unlockedPowerups = new HashSet<PlayerPowerup>();

    public bool SetHasPowerup(PlayerPowerup powerup) {
      return unlockedPowerups.Add(powerup);
    }

    public bool HasPowerup(PlayerPowerup powerup) {
      return unlockedPowerups.Contains(powerup);
    }


    private void Awake() {
      Instance = this;
    }
  }
}