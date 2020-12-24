using UnityEngine;
using System.Collections;
using System;

public abstract class BaseWeaponController : MonoBehaviour, IWeaponController {
  public abstract IWeaponDI DI { get; }
  public abstract void Inject(IWeaponDI di);
  public abstract bool LookAt(Vector2 destination);
  public abstract void PrimaryActionHold(bool hold);
  public abstract void PrimaryActionPress();
  public abstract void Reload();
  public abstract void SecondActionHold(bool hold);
  public abstract void SecondActionPress();
  public abstract Direction3 GetDirection3();
}
