using UnityEngine;
using System.Collections;
using TMPro;

public class WeaponHint : MonoBehaviour {

  [SerializeField]
  TextMeshProUGUI textMeshProUGUI;

  public void SetName(string name) {
    textMeshProUGUI.text = name;
  }
}
