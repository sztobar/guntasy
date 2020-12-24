using Input;
using Kite;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, InputActions.IGameplayActions, IPlayerInjectable {

  public float MoveInput { get; private set; }
  public Direction2H InputDirection { get; private set; } = Direction2H.Left;
  public Vector2 MouseWorldPosition { get; private set; }
  public Vector2 MousePixelViewportPosition { get; private set; }

  public bool JumpButtonPressed => jumpButtonPress.IsPressed();
  public void JumpButtonCancel() => jumpButtonPress.Cancel();
  public bool JumpButtonHeld => jumpButtonPress.IsHeld();

  public bool PrimaryActionPressed => primaryActionPress.IsPressed();
  public void PrimaryActionCancel() => primaryActionPress.Cancel();
  public bool PrimaryActionHeld => primaryActionPress.IsHeld();

  public bool SecondaryActionPressed => secondaryActionPress.IsPressed();
  public void SecondaryActionCancel() => secondaryActionPress.Cancel();
  public bool SecondaryActionHeld => secondaryActionPress.IsHeld();

  public bool DashButtonPressed => dashButtonPress.IsPressed();
  public void DashButtonCancel() => dashButtonPress.Cancel();
  public bool DashButtonHeld => dashButtonPress.IsHeld();

  public bool ActionButtonPressed => actionButtonPress.IsPressed();
  public void ActionButtonCancel() => actionButtonPress.Cancel();

  public bool ReloadButtonPressed => reloadButtonPress.IsPressed();
  public void ReloadButtonCancel() => reloadButtonPress.Cancel();

  public bool DodgeButtonPressed => dodgeButtonPress.IsPressed();
  public void DodgeButtonCancel() => dodgeButtonPress.Cancel();
  public bool JumpDownPressed => jumpDownButtonPress.IsPressed();
  public void JumpoDownCancel() => jumpDownButtonPress.Cancel();

  private InputActions inputActions;
  private readonly ActionPress reloadButtonPress = new ActionPress();
  private readonly ActionPress primaryActionPress = new ActionPress();
  private readonly ActionPress secondaryActionPress = new ActionPress();
  private readonly ActionPress jumpButtonPress = new ActionPress();
  private readonly ActionPress jumpDownButtonPress = new ActionPress();
  private readonly ActionPress dashButtonPress = new ActionPress();
  private readonly ActionPress actionButtonPress = new ActionPress();
  private readonly ActionPress dodgeButtonPress = new ActionPress();

  private CursorManager aimCursorManager;

  public void Inject(PlayerDI di) { }

  public void OnEnable() {
    aimCursorManager = CursorManager.Instance;
    if (inputActions == null) {
      inputActions = new InputActions();
      inputActions.Gameplay.SetCallbacks(this);
    }
    inputActions.Gameplay.Enable();
  }

  public void OnDisable() {
    inputActions.Gameplay.Disable();
  }

  public void OnMovement(InputAction.CallbackContext context) {
    MoveInput = context.ReadValue<float>();
    if (MoveInput != 0) {
      InputDirection = Direction2Helpers.FromFloat(MoveInput);
    }
  }

  public void OnJump(InputAction.CallbackContext context) {
    jumpButtonPress.OnInputAction(context);
  }

  public void OnMenu(InputAction.CallbackContext context) {
    if (context.performed && Time.timeScale > 0) {
      GameplayManager.Instance.OpenPauseMenu();
    }
  }

  private void Update() {
    ReadMouseAim();
    primaryActionPress.Update();
    secondaryActionPress.Update();
    jumpButtonPress.Update();
    dashButtonPress.Update();
    jumpDownButtonPress.Update();
  }

  public void ReadMouseAim() {
    Vector2 mouseScreenPosition = inputActions.Gameplay.MouseAim.ReadValue<Vector2>();
    Vector2 mouseViewportPosition = CameraManager.MainCamera.ScreenToViewportPoint(mouseScreenPosition);
    aimCursorManager.HideNativeIfInsideViewport(mouseViewportPosition);
    Vector2 confinedMouseViewportPosition = aimCursorManager.CursorConfiner.GetConfinedPosition(mouseViewportPosition);

    MouseWorldPosition = CameraManager.MainCamera.ViewportToWorldPoint(confinedMouseViewportPosition);
    MousePixelViewportPosition = CameraManager.Instance.ViewportToPixels(confinedMouseViewportPosition);
  }

  public void OnGamepadAim(InputAction.CallbackContext context) {
    if (context.performed) {
      Vector2 stickValue = context.ReadValue<Vector2>();
      if (stickValue != Vector2.zero) {
        // todo set mousePosition
      }
    }
  }

  public void OnMouseAim(InputAction.CallbackContext context) {
  }

  public void OnMouseDelta(InputAction.CallbackContext context) { }

  public void OnDash(InputAction.CallbackContext context) {
    dashButtonPress.OnInputAction(context);
  }

  public void OnAction(InputAction.CallbackContext context) {
    actionButtonPress.OnInputAction(context);
  }

  public void OnReload(InputAction.CallbackContext context) {
    reloadButtonPress.OnInputAction(context);
  }

  public void OnPrimaryAction(InputAction.CallbackContext context) {
    primaryActionPress.OnInputAction(context);
  }

  public void OnSecondaryAction(InputAction.CallbackContext context) {
    secondaryActionPress.OnInputAction(context);
  }

  public void OnDodge(InputAction.CallbackContext context) {
    dodgeButtonPress.OnInputAction(context);
  }

  public void OnJumpDown(InputAction.CallbackContext context) {
    jumpDownButtonPress.OnInputAction(context);
  }
}
