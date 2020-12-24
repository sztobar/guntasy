using UnityEngine;
using System.Collections;

namespace Kite {
  public class PlatformSkipabble : MonoBehaviour {

    [SerializeField] private float skipPlatformTime;

    private float skipPlatformTimeLeft;

    public bool CanSkip {
      get => skipPlatformTimeLeft > 0;
      set => skipPlatformTimeLeft = skipPlatformTime;
    }

    private void Update() {
      if (skipPlatformTimeLeft > 0) {
        skipPlatformTimeLeft -= Time.deltaTime;
      }
    }
  }
}