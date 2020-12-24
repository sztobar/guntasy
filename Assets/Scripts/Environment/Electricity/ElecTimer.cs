using UnityEngine;
using System.Collections;
using System;

namespace Environment.Electricity {
  public class ElecTimer : MonoBehaviour {

    [SerializeField]
    float timeOn;

    [SerializeField]
    float timeOff;

    [SerializeField]
    [Tooltip("Delay until the timer starts")]
    float timeOffset;

    [SerializeField]
    private bool initiallyOn;

    private float timeLeft;
    private bool elecOn;
    private bool timerOn = true;

    public Action<bool> OnElectricityChange { get; set; } = delegate { };
    public bool ElectricityOn => elecOn;

    public void DisableTimer() {
      timerOn = false;
      SetElecOff();
    }

    private void Awake() {
      if (initiallyOn) {
        SetElecOn();
      } else {
        SetElecOff();
      }
      OnElectricityChange(initiallyOn);
      timeLeft += timeOffset;
      if (timeOn > 0 && timeOff > 0) {
        timerOn = true;
      }
    }

    private void Update() {
      if (!timerOn) {
        return;
      }
      TimerUpdate();
    }

    private void TimerUpdate() {
      timeLeft -= Time.deltaTime;
      if (timeLeft <= 0) {
        Toggle();
      }
    }

    private void Toggle() {
      if (elecOn) {
        SetElecOff(); 
      } else {
        SetElecOn();
      }
      OnElectricityChange(elecOn);
    }

    private void SetElecOn() {
      elecOn = true;
      timeLeft = timeOn;
    }

    private void SetElecOff() {
      elecOn = false;
      timeLeft = timeOff;
    }
  }
}