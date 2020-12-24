using System.Collections;
using UnityEngine;

namespace Kite {

  public static class WaitForPlayFixedUpdate {

    private static readonly WaitForFixedUpdate next = new WaitForFixedUpdate();

    public static IEnumerator Create() {
      do {
        yield return next;
      } while (PauseManager.IsPaused);
    }

  }

  public static class WaitForPlayUpdate {

    public static IEnumerator Create() {
      do {
        yield return null;
      } while (PauseManager.IsPaused);
    }
  }
}
