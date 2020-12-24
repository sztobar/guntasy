using UnityEngine;
using System.Collections;

public abstract class BaseInaccuracyHandler : MonoBehaviour, IInaccuracyHandler {
  public Quaternion Inaccuracy { get; protected set; }
  public abstract void GenerateInaccuracy();
  public abstract void PerformFire();
  public abstract void Inject(IWeaponDI di);

  /// <summary>
  /// Genrates value between [-value/2, value/2]
  /// </summary>
  /// <param name="value"></param>
  protected float GenerateInaccuracy(float value) {
    var result = Random.value * value - value / 2f;
    Debug.Log($"[BaseInaccuracyHandler] inaccuracy angle: {result}");
    return result;
  }
}
