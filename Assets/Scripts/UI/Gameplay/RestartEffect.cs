using UnityEngine;
using Managers;
using Kite;

public class RestartEffect : MonoBehaviour {

  static private readonly int RESTART_HASH = Animator.StringToHash("Restart");

  [SerializeField]
  private Animator animator;

  [SerializeField]
  private AudioClip restartSound;

  private void Awake() {
    gameObject.SetActive(false);
  }

  public void StartEffect() {
    gameObject.SetActive(true);
    AudioSingleton.PlaySound(restartSound);
    animator.SetTrigger(RESTART_HASH);
  }


  public void OnRestartEnd() {
    GameplayManager.Instance.RestartLevelAfterEffect();
  }
}
