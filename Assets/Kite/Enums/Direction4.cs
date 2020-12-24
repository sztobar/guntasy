using UnityEngine;
using System;

namespace Kite {

  public enum Direction4 {
    Left,
    Right,
    Up,
    Down
  }

  public static class Direction4Helpers {

    public static Direction4 FromVector2Normal(Vector2 normal) {
      if (normal == Vector2.up) {
        return Direction4.Up;
      } else if (normal == Vector2.down) {
        return Direction4.Down;
      } else if (normal == Vector2.left) {
        return Direction4.Left;
      } else if (normal == Vector2.right) {
        return Direction4.Right;
      }
      throw new Exception($"Cannot convert non-normal Vector2 {normal} to Direction4");
    }

    public static Quaternion ToEulerQuaternion(this Direction4 direction) {
      switch (direction) {
        case Direction4.Up:
          return Quaternion.Euler(0, 0, 0);
        case Direction4.Left:
          return Quaternion.Euler(0, 0, 90);
        case Direction4.Down:
          return Quaternion.Euler(0, 0, 180);
        case Direction4.Right:
          return Quaternion.Euler(0, 0, 270);
        default:
          Debug.LogErrorFormat("Unhandled enum value: {0}", direction);
          return Quaternion.Euler(0, 0, 0);
      }
    }

    public static Vector3 ToVector3(this Direction4 direction, float length = 1.0f) {
      switch (direction) {
        case Direction4.Down:
          return new Vector3(0.0f, -length);
        case Direction4.Left:
          return new Vector3(-length, 0.0f);
        case Direction4.Right:
          return new Vector3(length, 0.0f);
        case Direction4.Up:
          return new Vector3(0.0f, length);
        default:
          Debug.LogErrorFormat("Unhandled enum value: {0}", direction);
          return new Vector3(0.0f, 0.0f);
      }
    }

    public static Vector2 ToVector2(this Direction4 direction, float length = 1.0f) {
      switch (direction) {
        case Direction4.Down:
          return new Vector2(0.0f, -length);
        case Direction4.Left:
          return new Vector2(-length, 0.0f);
        case Direction4.Right:
          return new Vector2(length, 0.0f);
        case Direction4.Up:
          return new Vector2(0.0f, length);
        default:
          Debug.LogErrorFormat("Unhandled enum value: {0}", direction);
          return new Vector2(0.0f, 0.0f);
      }
    }

    public static float ToFloat(this Direction4 direction) {
      switch (direction) {
        case Direction4.Down:
        case Direction4.Left:
          return -1f;
        case Direction4.Right:
        case Direction4.Up:
          return 1f;
        default:
          Debug.LogErrorFormat("Unhandled enum value: {0}", direction);
          return 0f;
      }
    }

    public static int ToVector2Index(this Direction4 direction) =>
      IsHorizontal(direction) ? 0 : 1;

    public static Orientation ToOrientation(this Direction4 direction) =>
      direction.IsHorizontal() ? Orientation.Horizontal : Orientation.Vertical;

    public static Direction4 FromFloatHorizontal(float sign) =>
      sign > 0 ? Direction4.Right : Direction4.Left;

    public static Direction4 FromFloatVertical(float sign) =>
      sign > 0 ? Direction4.Up : Direction4.Down;

    public static bool IsHorizontal(this Direction4 direction) =>
      direction == Direction4.Left || direction == Direction4.Right;

    public static bool IsVertical(this Direction4 direction) =>
      direction == Direction4.Up || direction == Direction4.Down;

    public static bool IsOrientation(this Direction4 direction, Orientation orientation) =>
      direction.ToOrientation() == orientation;

    public static bool IsPerpendicular(this Direction4 direction, Orientation orientation) =>
      direction.ToOrientation() != orientation;
  }
}