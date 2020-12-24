using UnityEngine;
using System.Collections.Generic;

namespace Kite {
  public interface IRaycaster {

    IEnumerable<RaycasterHit> GetHits(Vector2 position, float distance, Direction4 direction);

    IEnumerable<RaycasterHit> GetHits(Vector2 position, Vector2 ray);
  }
}