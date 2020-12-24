using UnityEngine;
using TMPro;
using Enums;

public class PowerupHint : MonoBehaviour {

  [SerializeField]
  TextMeshProUGUI textMeshProUGUI;

  public void SetName(PlayerPowerup powerup) {
    if (powerup == PlayerPowerup.Dash) {
      textMeshProUGUI.text = "Dash";
    } else {
      textMeshProUGUI.text = "Double jump";
    }
  }
}
