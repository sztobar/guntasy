using UnityEngine;
using System.Collections;

public abstract class BaseWeaponSMB : StateMachineBehaviour, IWeaponInjectable {
  public abstract void Inject(IWeaponDI di);
}
