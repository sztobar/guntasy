using UnityEngine;
using System.Collections;

public interface IInaccuracyHandler : IWeaponInjectable {
  Quaternion Inaccuracy { get; }
  void PerformFire();
  void GenerateInaccuracy();
}
