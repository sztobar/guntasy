using UnityEngine;
using Common;

public class WeaponSoundHandler : MonoBehaviour, IWeaponInjectable {

  [SerializeField] AudioSource fire;
  [SerializeField] AudioSource reload;

  private EmitDestructionItem projectileBoundToSound;
  private WeaponStateMachine stateMachine;

  public void Inject(IWeaponDI di) {
    stateMachine = di.StateMachine;
    stateMachine.OnWeaponEvent += OnWeaponEvent;
  }

  private void OnDisable() {
    if (stateMachine != null) {
      stateMachine.OnWeaponEvent -= OnWeaponEvent;
    }
  }

  private void OnWeaponEvent(WeaponEvent weaponEvent) {
    switch (weaponEvent) {
      case WeaponEvent.FireStart:
        PlayFire();
        break;
      case WeaponEvent.FireEnd:
        StopFire();
        break;
      case WeaponEvent.ReloadStart:
        PlayReload();
        break;
    }
  }

  public void PlayFire() {
    fire.Play();
  }

  public void PlayReload() {
    reload.Play();
  }

  internal void BindProjectileToSound(ProjectileSpawnable projectile) {
    if (projectileBoundToSound) {
      projectileBoundToSound.OnItemDestroy -= StopFire;
      projectileBoundToSound = null;
    }
    EmitDestructionItem emitDestruction = projectile.GetComponent<EmitDestructionItem>();
    if (emitDestruction) {
      projectileBoundToSound = emitDestruction;
      projectileBoundToSound.OnItemDestroy += StopFire;
    }
  }

  private void StopFire() {
    if (fire && fire.isPlaying) {
      fire.Stop();
    }
  }
}
