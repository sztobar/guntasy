using UnityEngine;
using System.Collections;

public interface IWeaponController: IWeaponInjectable {
  bool LookAt(Vector2 destination);
  Direction3 GetDirection3();
  void PrimaryActionPress();
  void PrimaryActionHold(bool hold);
  void Reload();
  void SecondActionPress();
  void SecondActionHold(bool hold);
}
