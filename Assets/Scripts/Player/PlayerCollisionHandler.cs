using UnityEngine;
using Enums;
using Player;
using Interactive;

public class PlayerCollisionHandler : MonoBehaviour, IDamagable, IPlayerInjectable {

  private PlayerWeaponArm weaponArm;
  private PlayerPowerupHandler powerupHandler;
  private PlayerHealthHandler healthHandler;
  private PlayerInputHandler inputHandler;
  private PlayerSoundHandler sound;
  private PlayerZappedHandler zappedHandler;

  public WeaponPickup CollidingWeaponPickup { get; set; }
  public PowerupPickup CollidingPowerupPickup { get; set; }

  public void Inject(PlayerDI di) {
    weaponArm = di.WeaponArm;
    powerupHandler = di.Powerup;
    healthHandler = di.Health;
    inputHandler = di.Input;
    sound = di.Sound;
    zappedHandler = di.Zapped;
  }

  public void UnlockPowerup(PlayerPowerup powerupType) {
    powerupHandler.UnlockPowerup(powerupType);
  }

  public bool TakeDamage(float damage, DamageType type) {
    if (healthHandler.IsVulnerable()) {
      bool isZap = type == DamageType.Electricity;
      healthHandler.ReceiveDamage(damage, isZap);
      if (isZap) {
        zappedHandler.Zap();
      }
      return true;
    }
    return false;
  }

  private void Update() {
    if (inputHandler.ActionButtonPressed) {
      if (CollidingWeaponPickup) {
        PickupWeapon();
      } else if (CollidingPowerupPickup) {
        PickPowerup();
      }
    }
  }

  private void PickupWeapon() {
    inputHandler.ActionButtonCancel();
    ScriptableWeapon previousWeapon = weaponArm.GetScriptableWeapon();
    weaponArm.SetScriptableWeapon(CollidingWeaponPickup.GetScriptableWeapon());
    CollidingWeaponPickup.SetScriptableWeapon(previousWeapon);
    sound.PlayWeaponSwap();
  }

  private void PickPowerup() {
    PlayerPowerup powerupType = CollidingPowerupPickup.Type;
    powerupHandler.UnlockPowerup(powerupType);
    CollidingPowerupPickup.PickupTaken();
    CollidingPowerupPickup = null;
  }

  public bool HealPlayer(float amount)
  {
    if (healthHandler.currentHP < healthHandler.maxHp)
    {
      healthHandler.Recover(amount);
      return true;
    }
    return false;
  }

  public bool ArmorPlayer()
  {
    if (healthHandler.currentArmor < healthHandler.maxArmor)
    {
      healthHandler.GetArmor();
      return true;
    }
    return false;
  }
}
