using UnityEngine;
using System.Collections;
using UI.Bars;
using UnityEngine.UI;
using Managers;

namespace UI.Gameplay {
  public class ArmorUI : MonoBehaviour {

    [SerializeField]
    private Image icon;

    [SerializeField]
    private PlayerBar bar;

    private void Update() {
      bool hasArmor = PlayerManager.Instance.ArmorPercentage > 0;
      icon.gameObject.SetActive(hasArmor);
      bar.gameObject.SetActive(hasArmor);
    }
  }
}