using UnityEngine;
using System.Collections;

public class GunDI : MonoBehaviour, IWeaponDI {

  [SerializeField] private GunController controller;
  [SerializeField] private BaseWeaponAimHandler aimHandler;
  [SerializeField] private WeaponAmmoHandler ammoHandler;
  [SerializeField] private BaseWeaponFileHandler fireHandler;
  [SerializeField] private BaseWeaponRecoil weaponRecoil;
  [SerializeField] private GunAnimator weaponAnimator;
  [SerializeField] private Direction3Animator weaponDirectionAnimator;
  [SerializeField] private WeaponSoundHandler gunSoundHandler;
  [SerializeField] private WeaponCrosshairHandler gunCrosshairHandler;
  [SerializeField] private CameraEmitShake cameraEmitShake;
  [SerializeField] private BaseInaccuracyHandler inaccuracyHandler;
  [SerializeField, HideInInspector] private WeaponStateMachine stateMachine;

  BaseWeaponController IWeaponDI.Controller => controller;
  IWeaponAimHandler IWeaponDI.AimHandler => aimHandler;
  IWeaponAmmoHandler IWeaponDI.AmmoHandler => ammoHandler;
  IWeaponFireHandler IWeaponDI.FireHandler => fireHandler;
  IWeaponAnimator IWeaponDI.WeaponAnimator => weaponAnimator;
  IInaccuracyHandler IWeaponDI.InaccuracyHandler => inaccuracyHandler;
  IWeaponRecoil IWeaponDI.WeaponRecoil => weaponRecoil;
  WeaponStateMachine IWeaponDI.StateMachine => stateMachine;
  Direction3Animator IWeaponDI.WeaponDirectionAnimator => weaponDirectionAnimator;
  WeaponSoundHandler IWeaponDI.SoundHandler => gunSoundHandler;
  WeaponCrosshairHandler IWeaponDI.CrosshairHandler => gunCrosshairHandler;
  CameraEmitShake IWeaponDI.CameraEmitShake => cameraEmitShake;
  PlayerDI IWeaponDI.PlayerDI { get; set; }

  private void Awake() {
    //Init();
  }

  public void Init() {
    stateMachine = new WeaponStateMachine();
    controller.Inject(this);
    aimHandler.Inject(this);
    weaponAnimator.Inject(this);
    ammoHandler.Inject(this);
    fireHandler.Inject(this);
    inaccuracyHandler.Inject(this);
    weaponRecoil.Inject(this);
    gunSoundHandler.Inject(this);
    gunCrosshairHandler.Inject(this);
  }
}
