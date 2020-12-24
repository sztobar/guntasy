using System;

[Serializable]
public class WeaponStateMachine {

  public delegate void WeaponEventDelegage(WeaponEvent weaponEvent);
  public event WeaponEventDelegage OnWeaponEvent;

  private WeaponState state = WeaponState.Idle;

  public void EmitEvent(WeaponEvent weaponEvent) {
    if (weaponEvent == WeaponEvent.None) {
      return;
    }
    SetStateAfterEvent(weaponEvent);
    OnWeaponEvent(weaponEvent);
  }

  private void SetStateAfterEvent(WeaponEvent weaponEvent) {
    switch (weaponEvent) {
      case WeaponEvent.ReloadStart:
        state = WeaponState.Reload;
        break;
      case WeaponEvent.FireStart:
        state = WeaponState.Fire;
        break;
      case WeaponEvent.FireEnd:
      case WeaponEvent.ReloadEnd:
      case WeaponEvent.DodgeRollEnd:
        state = WeaponState.Idle;
        break;
      case WeaponEvent.DodgeLeapStart:
        state = WeaponState.Dodge;
        break;
    }
  }

  public bool IsReloading() {
    return state == WeaponState.Reload;
  }
}
