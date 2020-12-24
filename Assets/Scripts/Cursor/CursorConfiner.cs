using System;
using UnityEngine;

[Serializable]
public class CursorConfiner {
  
  private Vector2 viewportConfinerMin = Vector2.zero;
  private Vector2 viewportConfinerMax = Vector2.one;
  
  public Vector2 GetConfinedPosition(Vector2 mouseViewportPosition) {
    return new Vector2(
      Mathf.Clamp(mouseViewportPosition.x, viewportConfinerMin.x, viewportConfinerMax.x),
      Mathf.Clamp(mouseViewportPosition.y, viewportConfinerMin.y, viewportConfinerMax.y)
    );
  }

  public void SetViewportConfiner(Vector2 confiner) {
    viewportConfinerMin = new Vector2((1 - confiner.x) / 2, (1 - confiner.y) / 2);
    viewportConfinerMax = new Vector2(
      1 - viewportConfinerMin.x,
      1 - viewportConfinerMin.y
    );
  }

  public void ResetViewportConfiner() {
    viewportConfinerMin = Vector2.zero;
    viewportConfinerMax = Vector2.one;
  }
}