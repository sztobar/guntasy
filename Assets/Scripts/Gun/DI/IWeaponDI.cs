using UnityEngine;
using System.Collections;

public interface IWeaponDI {
  void Init();

  PlayerDI PlayerDI { get; set; }
  BaseWeaponController Controller { get; }
  WeaponStateMachine StateMachine { get; }
  IWeaponAimHandler AimHandler { get; }
  IWeaponAmmoHandler AmmoHandler { get; }
  IWeaponFireHandler FireHandler { get; }
  IWeaponAnimator WeaponAnimator { get; }
  IInaccuracyHandler InaccuracyHandler { get; }
  IWeaponRecoil WeaponRecoil { get; }
  Direction3Animator WeaponDirectionAnimator { get; }
  WeaponSoundHandler SoundHandler { get; }
  WeaponCrosshairHandler CrosshairHandler { get; }
  CameraEmitShake CameraEmitShake { get; }
}
