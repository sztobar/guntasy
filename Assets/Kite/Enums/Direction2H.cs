using System;
using UnityEngine;

namespace Kite {

  public enum Direction2H {
    Right = 1,
    Left = -1,
  }

  public static class Direction2Helpers {

    public static Direction2H Flip(this Direction2H value) {
      return value == Direction2H.Left ? Direction2H.Right : Direction2H.Left;
    }

    public static float ToFloat(this Direction2H value) {
      return value == Direction2H.Left ? -1 : 1;
    }

    public static Vector2 ToVector2(this Direction2H value, float distance = 1f) {
      return value == Direction2H.Left ? Vector2.left : Vector2.right * distance;
    }

    public static Direction2H FromDirection4(Direction4 direction) {
      if (direction.IsVertical()) {
        throw new Exception("Passed vertical direction4 in place of horizontal");
      }
      return direction == Direction4.Left ? Direction2H.Left : Direction2H.Right;
    }

    public static Vector3 ToVector3(this Direction2H value) {
      return value == Direction2H.Left ? Vector3.left : Vector3.right;
    }
    public static Direction2H FromFloat(float value) {
      return value > 0 ? Direction2H.Right : Direction2H.Left;
    }

    public static Direction2H Random() {
      float value = UnityEngine.Random.value * 2 - 1;
      return FromFloat(value);
    }
  }
}