using UnityEngine;
using System.Collections;

public interface IWeaponAmmoHandler : IWeaponInjectable {
  float GetAmmoPercentage();
  void UseAmmo();
  void Reload();
  bool HasAmmo();
  void SetReloadPercentage(float normalizedTime);
}
