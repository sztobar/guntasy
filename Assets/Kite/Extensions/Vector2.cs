using UnityEngine;

namespace Kite {
  public static class Vector2Extensions {

    public static Direction4 ToDirection4Horizontal(this Vector2 vector) {
      return vector.x >= 0 ? Direction4.Right : Direction4.Left;
    }

    public static Direction4 ToDirection4Vertical(this Vector2 vector) {
      return vector.y >= 0 ? Direction4.Up : Direction4.Down;
    }

    public static Direction4 ToDirection4InAxis(this Vector2 vector, int axis) {
      return axis == 0 ? ToDirection4Horizontal(vector) : ToDirection4Vertical(vector);
    }

    public static bool HasValueInDirection(this Vector2 vector, Direction4 direction) {
      return ToDirection4InAxis(vector, direction.ToVector2Index()) == direction;
    }

    public static Vector2 DegreeToVector2(float degree) {
      float radian = degree * Mathf.Deg2Rad;
      return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 QuaternionToVector2(Quaternion quaternion) {
      Vector3 eulerAngles = quaternion.eulerAngles;
      float y = eulerAngles.y;
      float z = eulerAngles.z;
      if (Mathf.RoundToInt(y) == 0) {
        return DegreeToVector2(z);
      } else {
        return DegreeToVector2(y - z);
      }
    }

    public static Vector2 Rotate(this Vector2 vector, float degrees) {
      return Quaternion.Euler(0, 0, degrees) * vector;
    }

    public static float GetValue(this Vector2 vector, Orientation orientation) =>
      vector[orientation.ToVector2Index()];
  }
}