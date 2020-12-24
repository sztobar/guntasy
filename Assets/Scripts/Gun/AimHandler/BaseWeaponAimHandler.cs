using UnityEngine;
using System.Collections;

public abstract class BaseWeaponAimHandler : MonoBehaviour, IWeaponAimHandler {
  public abstract Vector2 MousePosition { get; }
  public abstract void FocusAim(bool focus);
  public abstract Direction3 GetDirection3();
  public abstract Quaternion GetFireRotation();
  public abstract void Inject(IWeaponDI di);
  public abstract bool LookAt(Vector2 destination);
}
