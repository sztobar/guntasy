using UnityEngine;
using System.Collections;
using Enums;
using UnityEngine.UI;
using Managers;

namespace UI.Gameplay {
  public class PowerupIcon : MonoBehaviour {

    [SerializeField]
    private PlayerPowerup type;

    [SerializeField]
    private Image image;

    private void Update() {
      image.enabled = PlayerManager.Instance.HasPowerup(type);
    }
  }
}
