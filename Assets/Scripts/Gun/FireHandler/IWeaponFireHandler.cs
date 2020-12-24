using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponFireHandler : IWeaponInjectable {
  void AutoFire();
  void Fire();
  bool CanFire();
  bool HasAutoFire();
}
