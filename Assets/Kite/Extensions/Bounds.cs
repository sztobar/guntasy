using UnityEngine;

namespace Kite {
  public static class BoundsExtensions {

    public static Vector2 GetEnd(this Bounds bounds, Direction2H horizontalDir, Direction2V vericalDir) =>
      new Vector2(
        horizontalDir == Direction2H.Left ? bounds.min.x : bounds.max.y,
        vericalDir == Direction2V.Down ? bounds.min.y : bounds.max.y
      );

    public static Vector2 GetEnd(this Bounds bounds, Direction4 horizontalDir4, Direction4 vericalDir4) =>
      bounds.GetEnd(
        Direction2Helpers.FromDirection4(horizontalDir4),
        Direction2VHelpers.FromDirection4(vericalDir4)
      );
  }
}