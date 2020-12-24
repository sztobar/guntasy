using UnityEngine;
using System.Collections;

public interface IWeaponAimHandler : IWeaponInjectable {
  Vector2 MousePosition { get; }

  bool LookAt(Vector2 destination);
  Quaternion GetFireRotation();
  void FocusAim(bool focus);
  Direction3 GetDirection3();
}
