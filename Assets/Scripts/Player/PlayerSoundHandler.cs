using UnityEngine;
using System.Collections;
using System;

public class PlayerSoundHandler : MonoBehaviour, IPlayerInjectable {

  [SerializeField] AudioSource weaponSwap;
  [SerializeField] AudioSource footSteps;
  [SerializeField] AudioSource jump;
  [SerializeField] AudioSource dash;

  [SerializeField] AudioSource hpGet;
  [SerializeField] AudioSource powerupGet;
  [SerializeField] AudioSource hit;

  public void Inject(PlayerDI di) { }

  public void PlayWeaponSwap() {
    weaponSwap.Play();
  }

  public void PlayJump() {
    jump.Play();
  }

  public void PlayDash() {
    dash.Play();
  }

  public void PlayHpGet() {
    hpGet.Play();
  }

  public void PlayPowerupGet() {
    powerupGet.Play();
  }

  public void PlayHit() {
    hit.Play();
  }

  public void PlayWalk(bool isWalking) {
    if (isWalking && !footSteps.isPlaying) {
      footSteps.Play();
    } else if (!isWalking && footSteps.isPlaying) {
      footSteps.Stop();
    }
  }
}
