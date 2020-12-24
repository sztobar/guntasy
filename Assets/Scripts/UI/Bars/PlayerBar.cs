using UnityEngine;
using System.Collections;
using Managers;

namespace UI.Bars {
  public class PlayerBar : BaseBar {

    [SerializeField]
    private Property property;

    private void Update() {
      SetPercentage(GetValue());
    }

    private float GetValue() {
      switch (property) {
        case Property.Hp:
          return PlayerManager.Instance.HpPercentage;
        case Property.Armor:
          return PlayerManager.Instance.ArmorPercentage;
        case Property.Ammo:
        default:
          return PlayerManager.Instance.AmmoPercentage;
      }
    }

    enum Property {
      Hp,Armor,Ammo
    }

  }
}