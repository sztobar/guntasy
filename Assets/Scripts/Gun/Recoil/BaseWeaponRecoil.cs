using UnityEngine;
using System.Collections;

public abstract class BaseWeaponRecoil : MonoBehaviour, IWeaponRecoil {
  public Quaternion Recoil { get; protected set; } = Quaternion.identity;
  public abstract void Inject(IWeaponDI di);
  public abstract void PerformFire();
}
