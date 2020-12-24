using UnityEngine;
using System.Collections;

public interface IWeaponAnimator : IWeaponInjectable {
  bool IsReloading();
  void PlayFire();
  void PlayReload();
  void PlayDodgeLeap();
  void PlayDodgeRoll();
}
