using UnityEngine;
using Enums;
using Player;
using Managers;

public class PlayerPowerupHandler : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  private bool hasDoubleJump = true;

  [SerializeField]
  private bool hasDash = true;

  [SerializeField]
  private bool hasWallSlide = true;

  private PlayerSoundHandler soundHandler;

  public bool CanDoubleJump => hasDoubleJump;
  public bool CanDash => hasDash;
  public bool CanWallSlide => hasWallSlide;

  public void Inject(PlayerDI di) {
    soundHandler = di.Sound;
  }

  public void UnlockPowerup(PlayerPowerup powerup) {
    soundHandler.PlayPowerupGet();
    PlayerManager.Instance.SetHasPowerup(powerup);
    switch (powerup) {
      case PlayerPowerup.DoubleJump:
        hasDoubleJump = true;
        break;
      case PlayerPowerup.Dash:
        hasDash = true;
        break;
      case PlayerPowerup.WallSlide:
        hasWallSlide = true;
        break;
    }
  }

  public void ResetPowerups() {
    hasDoubleJump = false;
    hasDash = false;
    hasWallSlide = false;
  }
}
