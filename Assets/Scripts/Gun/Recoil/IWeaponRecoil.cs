using UnityEngine;
using System.Collections;

public interface IWeaponRecoil : IWeaponInjectable {
  Quaternion Recoil { get; }
  void PerformFire();
}
