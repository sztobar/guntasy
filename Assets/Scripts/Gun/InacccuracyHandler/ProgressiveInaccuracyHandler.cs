using UnityEngine;
using System.Collections;

public class ProgressiveInaccuracyHandler : BaseInaccuracyHandler {

  [SerializeField]
  private float startInaccuracyAngle;

  [SerializeField]
  private float endInaccuracyAngle;

  [SerializeField]
  [Tooltip("How many should inaccuracy change from start to end")]
  private AnimationCurve startToEndInaccuracyCurve = AnimationCurve.Linear(0, 0, 1, 1);

  [SerializeField]
  [Tooltip("How many shots are using startInaccuracyAngle before counting them towards shotsToEndInaccuracy")]
  private int shotsOnStartInaccuracy;

  [SerializeField]
  [Tooltip("How many shots are needed to get from start to end inaccuracy value")]
  private int shotsToEndInaccuracy;

  [SerializeField]
  [Tooltip("Time after last shot when inaccuracy starts to go back to start value")]
  private float delayToStartRecover;

  [SerializeField]
  [Tooltip("Time to get back from end to start inaccuracy")]
  private float recoverTime;

  private int currentShots;
  private float delayTimeLeft;
  private float recoverTimeLeft;

  public override void GenerateInaccuracy() {
    float shotsPercent = Mathf.Max(currentShots - shotsOnStartInaccuracy, 0) / (float)shotsToEndInaccuracy;
    float t = startToEndInaccuracyCurve.Evaluate(shotsPercent);
    float angle = Mathf.Lerp(startInaccuracyAngle, endInaccuracyAngle, t);
    Debug.Log($"[ProgressiveInaccuracyHandler]: inaccuracy t: {t}; angle: {angle}");
    Inaccuracy = Quaternion.Euler(0, 0, GenerateInaccuracy(angle));
  }

  public override void Inject(IWeaponDI di) {
  }

  public override void PerformFire() {
    currentShots = Mathf.Min(currentShots + 1, shotsOnStartInaccuracy + shotsToEndInaccuracy);
    delayTimeLeft = delayToStartRecover;
  }

  private void Update() {
    if (delayTimeLeft > 0) {
      delayTimeLeft -= Time.deltaTime;
      if (delayTimeLeft <= 0) {
        recoverTimeLeft = Mathf.Lerp(0, recoverTime, currentShots / shotsToEndInaccuracy);
        Debug.Log($"[ProgressiveInaccuracyHandler]: recover time start");
      }
    } else if (recoverTimeLeft > 0) {
      recoverTimeLeft -= Time.deltaTime;
      if (recoverTimeLeft <= 0) {
        Debug.Log($"[ProgressiveInaccuracyHandler]: recover time end");
        currentShots = 0;
      }
    }
  }
}
