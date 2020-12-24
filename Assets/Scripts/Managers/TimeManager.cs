using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TimeManager : MonoBehaviour {

  [SerializeField]
  private float keyDelay;

  [SerializeField]
  private float timeStep;

  [SerializeField]
  private float maxTime;
  
  [SerializeField]
  private float minTime;

  [SerializeField]
  private float timeScale = 1f;

  private float keyDelayLeft;

  void Start() {

  }

  void Update() {
    if (keyDelayLeft > 0) {
      keyDelayLeft -= Time.unscaledDeltaTime;
      return;
    }
    if (Keyboard.current.leftBracketKey.isPressed) {
      Time.timeScale = Mathf.Clamp(Time.timeScale - timeStep, minTime, maxTime);
      keyDelayLeft = keyDelay;
    } else if (Keyboard.current.rightBracketKey.isPressed) {
      Time.timeScale = Mathf.Clamp(Time.timeScale + timeStep, minTime, maxTime);
      keyDelayLeft = keyDelay;
    }
    timeScale = Time.timeScale;
  }
}
