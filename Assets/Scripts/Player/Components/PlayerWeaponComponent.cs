using Kite;
using System;
using UnityEngine;

public class PlayerWeaponComponent : PlayerComponent {

  #region dependencies
  private PlayerWeaponArm weaponArm;
  private PlayerInputHandler input;
  private HorizontalFlipComponent playerFlip;
  private PlayerDodgeComponent dodge;
  #endregion

  public override void PlayerAwake(PlayerGameplayController controller) {
    weaponArm = controller.DI.WeaponArm;
    input = controller.DI.Input;
    playerFlip = controller.DI.Flip;
    dodge = controller.Dodge;
  }

  protected override void PlayerFixedUpdateImpl() {
    if (input.PrimaryActionPressed) {
      input.PrimaryActionCancel();
      weaponArm.Weapon.PrimaryActionPress();
    }
    weaponArm.Weapon.PrimaryActionHold(input.PrimaryActionHeld);
    if (input.ReloadButtonPressed) {
      input.ReloadButtonCancel();
      weaponArm.Weapon.Reload();
    }
    if (input.SecondaryActionPressed) {
      input.SecondaryActionCancel();
      weaponArm.Weapon.SecondActionPress();
    }
    weaponArm.Weapon.SecondActionHold(input.SecondaryActionHeld);
    MousePositionUpdate();
  }

  private void MousePositionUpdate() {
    Vector2 mousePosition = input.MouseWorldPosition;
    bool canLook = weaponArm.Weapon.LookAt(mousePosition);
    if (canLook && !dodge.IsDodging()) {
      SetPlayerDirectionAt(mousePosition);
    }
  }

  private void SetPlayerDirectionAt(Vector2 mousePosition) {
    Vector2 aim = mousePosition - (Vector2)weaponArm.transform.position;
    Direction2H aimDirection = Direction2Helpers.FromFloat(aim.x);
    playerFlip.Direction = aimDirection;
  }
}