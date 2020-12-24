using UnityEngine;
using System.Collections.Generic;
using System;

namespace Kite {

  [Serializable]
  public class RaycasterHitsFactory {

    private readonly Dictionary<Transform, RaycastHit2D> uniqueHits = new Dictionary<Transform, RaycastHit2D>();
    private readonly List<RaycastHit2D> outputHit2D = new List<RaycastHit2D>();

    public List<RaycastHit2D> GetUnique(RaycastHit2D[] hits) {
      uniqueHits.Clear();
      outputHit2D.Clear();
      for (int i = 0; i < hits.Length; i++) {
        RaycastHit2D hit = hits[i];
        if (!hit) {
          continue;
        }

        if (!uniqueHits.ContainsKey(hit.transform)) {
          uniqueHits.Add(hit.transform, hit);
        } else if (uniqueHits[hit.transform].distance > hit.distance) {
          uniqueHits[hit.transform] = hit;
        }
      }
      outputHit2D.AddRange(uniqueHits.Values);
      return outputHit2D;
    }

    public IEnumerable<RaycasterHit> GetUniqueRaycasterHits(RaycastHit2D[] hits) {
      List<RaycastHit2D> uniqeHits = GetUnique(hits);
      foreach (RaycastHit2D hit in uniqeHits) {
        yield return new RaycasterHit(hit);
      }
    }
  }
}