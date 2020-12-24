using UnityEngine;
using System.Collections;
using Enums;

namespace Environment.Electricity {
  public class ElecStation : MonoBehaviour, IDamagable {

    [SerializeField]
    ElecTimer timer;

    [SerializeField]
    ElecAnimator animator;

    [SerializeField]
    private bool destroyable;

    public void CurrentOn() {
      animator.CurrentOn();
    }

    public void CurrentOff() {
      animator.CurrentOff();
    }

    public bool TakeDamage(float damage, DamageType type) {
      if (destroyable && type == DamageType.Explosion && damage > 0) {
        timer.DisableTimer();
        Destroy(gameObject);
      }
      return true;
    }
  }
}