using UnityEngine;
using UI.Screens;
using Input;
using UnityEngine.InputSystem;
using Managers;

namespace UI.Controllers {
  public class PauseMenuController : MonoBehaviour {

    [SerializeField]
    private MenuScreen mainMenu;

    [SerializeField]
    private MenuScreen optionsMenu;

    private InputActions inputActions;

    public void Open() {
      gameObject.SetActive(true);
    }

    public void Close() {
      gameObject.SetActive(false);
    }

    public void OpenOptionsScreen() {
      mainMenu.Close();
      optionsMenu.SetSelectedOptionIndex(0);
      optionsMenu.Open();
    }

    public void OpenMainScreen() {
      optionsMenu.Close();
      mainMenu.Open();
    }

    private void OnEnable() {
      if (inputActions == null) {
        inputActions = new InputActions();
        inputActions.Menu.Back.performed += HandleBackPerformed;
      }
      inputActions.Menu.Enable();
    }

    private void OnDisable() {
      inputActions.Menu.Disable();
    }

    private void HandleBackPerformed(InputAction.CallbackContext context) {
      GameplayManager.Instance.ResumeGameplay();
    }

  }
}