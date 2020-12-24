using System.Collections;
using UnityEngine;

namespace Kite {

  public  class WaitForPlaySeconds : IEnumerator {

    private float elapsedTime = 0f;
    private readonly float duration;

    public object Current => elapsedTime;

    public WaitForPlaySeconds(float seconds) {
      duration = seconds;
    }

    public bool MoveNext() {
      if (!PauseManager.IsPaused) {
        elapsedTime += Time.deltaTime;
      }
      return elapsedTime < duration;
    }

    public void Reset() {}
  }
}
