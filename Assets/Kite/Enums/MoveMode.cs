namespace Kite {

  public enum MoveMode {
    HorizontalFirst,
    VerticalFirst
  }

  public static class MoveModeExtensions {

    private static readonly int[] horizontalFirstVectorIndexes = new int[] { 0, 1 };
    private static readonly int[] verticalFirstVectorIndexes = new int[] { 1, 0 };

    public static int[] GetVectorIndexes(this MoveMode mode) =>
      mode == MoveMode.HorizontalFirst
      ? horizontalFirstVectorIndexes
      : verticalFirstVectorIndexes;

    public static int GetVectorIndex(this MoveMode mode) =>
      mode == MoveMode.HorizontalFirst ? 0 : 1;

    public static int GetNextVectorIndex(this MoveMode mode) =>
      mode == MoveMode.HorizontalFirst ? 1 : 0;
  }
}