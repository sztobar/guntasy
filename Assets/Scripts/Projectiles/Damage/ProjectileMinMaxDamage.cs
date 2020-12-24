using UnityEngine;
using System.Collections;

public class ProjectileMinMaxDamage : BaseProjectileDamage {

  [SerializeField]
  [Tooltip("Start Damage until startDamageTime")]
  private float startDamage;

  [SerializeField]
  [Tooltip("End Damage after endDamageTime")]
  private float endDamage;

  [SerializeField]
  [Tooltip("Duration of startDamage")]
  private float startDamageTime;

  [SerializeField]
  [Tooltip("Time to reach endDamage")]
  private float endDamageTime;

  private float elapsedTime;

  protected void Awake() {
    elapsedTime = 0;
  }

  void FixedUpdate() {
    elapsedTime += Time.deltaTime;
  }

  private float CalculateDamageTime(float elapsedTime) {
    float changeDuration = endDamageTime - startDamageTime;
    float currentTime = Mathf.Clamp(elapsedTime - startDamageTime, 0, changeDuration);
    return currentTime / changeDuration;
  }

  public override float GetDamage() {
    float damageTime = CalculateDamageTime(elapsedTime);
    float damage = Mathf.Lerp(startDamage, endDamage, damageTime);

    Debug.Log($"[ProjectileMinMaxDamage] lifeTime: {elapsedTime}; damage%: {CalculateDamageTime(damageTime)}; damage: {damage}");

    return damage;
  }
}
