using UnityEngine;
using UI.Controllers;
using UnityEngine.SceneManagement;
using Kite;
using System;

namespace Managers {
  public class GameplayManager : MonoBehaviour {

    public static GameplayManager Instance;

    [SerializeField]
    private PauseMenuController pauseMenuController;

    [SerializeField]
    private GameOverController gameOverController;

    [SerializeField]
    private GameplayUIController gameplayUIController;

    [SerializeField]
    private AudioClip levelMusic;

    [SerializeField]
    RestartEffect restartEffect;


    private void Awake() {
      Time.timeScale = 1f;
      Instance = this;
      AudioSingleton.Init();
      AudioSingleton.PlayMusic(levelMusic);
    }

    public void OpenPauseMenu() {
      pauseMenuController.Open();
      gameplayUIController.Close();
      Time.timeScale = 0f;
    }

    public void ResumeGameplay() {
      pauseMenuController.Close();
      gameplayUIController.Open();
      Time.timeScale = 1f;
    }

    public void RestartLevel() {
      Time.timeScale = 0f;
      restartEffect.StartEffect();
    }

    public void RestartLevelAfterEffect() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    internal void GoToCredits() {
      SceneManager.LoadScene(UnityConstants.Scenes._3__Credits);
    }

    public void GameOver() {
      RestartLevel();
    }

  }
}