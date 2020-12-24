using UnityEngine;
using System.Collections;

public abstract class BaseWeaponFileHandler : MonoBehaviour, IWeaponFireHandler {
  public abstract void AutoFire();
  public abstract bool CanFire();
  public abstract void Fire();
  public abstract bool HasAutoFire();
  public abstract void Inject(IWeaponDI di);
}
