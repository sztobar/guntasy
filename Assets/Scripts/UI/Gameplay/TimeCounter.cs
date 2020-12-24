using UnityEngine;
using TMPro;
using Managers;
using Kite;

namespace UI.Gameplay {
  public class TimeCounter : MonoBehaviour {

    [SerializeField]
    private float initialTime = 300;

    [SerializeField]
    private float alarmTime = 60;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private AudioClip alarmSound;

    private float timeLeft;
    private bool alarmRinged;

    private void Awake() {
      timeLeft = initialTime;
    }

    private void Update() {
      if (timeLeft >= 0) {
        timeLeft -= Time.deltaTime;
        text.text = GetTimeText();
        if (timeLeft <= 0) {
          //TODO: If there is time, add restart and some nice rewind effect
          GameplayManager.Instance.GameOver();
        }
        if (!alarmRinged && timeLeft <= alarmTime) {
          alarmRinged = true;
          AudioSingleton.PlaySound(alarmSound);
        }
      }
    }

    private string GetTimeText() {
      int minutes = (int) (timeLeft / 60f);
      int seconds = (int) (timeLeft - (minutes * 60f));
      return string.Format("{0:D2}:{1:D2}", minutes, seconds );
    }
  }
}