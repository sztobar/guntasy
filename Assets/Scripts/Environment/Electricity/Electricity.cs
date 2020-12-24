using UnityEngine;
using System.Collections;
using System;

namespace Environment.Electricity {
  public class Electricity : MonoBehaviour {

    [SerializeField]
    ElecStation station1;

    [SerializeField]
    ElecStation station2;

    [SerializeField]
    new ElecCollider collider;

    [SerializeField]
    ElecTimer timer;

    private void Awake() {
      timer.OnElectricityChange += HandleElectricityChange;
      HandleElectricityChange(timer.ElectricityOn);
    }

    private void HandleElectricityChange(bool elecOn) {
      if (elecOn) {
        CurrentOn();
      } else {
        CurrentOff();
      }
    }

    private void CurrentOff() {
      station1.CurrentOff();
      station2.CurrentOff();
      collider.CurrentOff();
    }

    private void CurrentOn() {
      station1.CurrentOn();
      station2.CurrentOn();
      collider.CurrentOn();
    }
  }
}