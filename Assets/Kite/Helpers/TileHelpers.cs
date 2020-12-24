using UnityEngine;

namespace Kite {
  public static class TileHelpers {

    public const float TILE_SIZE = 16;
    public const float HALF_TILE_SIZE = 8;

    public static float TileToWorld(float value) => value * TILE_SIZE;

    public static float Floor(float value) => Mathf.Floor(value / TILE_SIZE) * TILE_SIZE;

    public static float Ceil(float value) => Mathf.Ceil(value / TILE_SIZE) * TILE_SIZE;
  }
}