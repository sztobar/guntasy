using UnityEngine;
using System.Collections;

namespace Kite {
  public interface ICollisionMove {
    float GetAllowedMoveInto(RaycasterHit hit, float distance);
  }
}