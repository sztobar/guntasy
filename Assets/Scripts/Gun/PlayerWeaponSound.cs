using UnityEngine;
using System.Collections;
using Enums;

namespace Gun {
  public class PlayerWeaponSound : MonoBehaviour {

    [SerializeField]
    AudioSource fireSource;

    [SerializeField]
    AudioSource reloadSource;

    public void PlayFire(AudioClip fire) {
      fireSource.PlayOneShot(fire);
    }

    public void PlayReload(AudioClip reload) {
      fireSource.PlayOneShot(reload);
    }
  }
}