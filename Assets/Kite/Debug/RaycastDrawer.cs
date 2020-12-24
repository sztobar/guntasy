using UnityEngine;
using System.Collections;

namespace Kite {
  public static class RaycastDrawer {

    public static void Draw(Bounds bounds, Direction4 direction, float length = 1f) {
      if (direction.IsHorizontal()) {
        Vector2 originTop = (Vector2)bounds.center + new Vector2(bounds.extents.x * direction.ToFloat(), bounds.extents.y);
        Debug.DrawLine(originTop, originTop + direction.ToVector2(length), Color.magenta);

        Vector2 originCenter = (Vector2)bounds.center + new Vector2(bounds.extents.x * direction.ToFloat(), 0);
        Debug.DrawLine(originCenter, originCenter + direction.ToVector2(length), Color.magenta);

        Vector2 originBottom = (Vector2)bounds.center + new Vector2(bounds.extents.x * direction.ToFloat(), -bounds.extents.y);
        Debug.DrawLine(originBottom, originBottom + direction.ToVector2(length), Color.magenta);
      } else {
        Vector2 originLeft = (Vector2)bounds.center + new Vector2(-bounds.extents.x, bounds.extents.y * direction.ToFloat());
        Debug.DrawLine(originLeft, originLeft + direction.ToVector2(length), Color.magenta);

        Vector2 originCenter = (Vector2)bounds.center + new Vector2(0, bounds.extents.y * direction.ToFloat());
        Debug.DrawLine(originCenter, originCenter + direction.ToVector2(length), Color.magenta);

        Vector2 originRight = (Vector2)bounds.center + new Vector2(bounds.extents.x, bounds.extents.y * direction.ToFloat());
        Debug.DrawLine(originRight, originRight + direction.ToVector2(length), Color.magenta);
      }
    }
  }
}