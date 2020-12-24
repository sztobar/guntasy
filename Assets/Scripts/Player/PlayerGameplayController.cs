using Kite;
using UnityEngine;

public class PlayerGameplayController : MonoBehaviour {

  #region Components
  [Header("Components")]
  [SerializeField] PlayerWeaponComponent weapon;
  [SerializeField] PlayerGroundComponent ground;
  [SerializeField] PlayerWalkComponent walk;
  [SerializeField] PlayerJumpComponent jump;
  [SerializeField] PlayerDashComponent dash;
  [SerializeField] PlayerDodgeComponent dodge;
  #endregion Components

  #region Dependencies
  [Header("Dependencies")]
  [SerializeField] PlayerDI di;
  #endregion

  private PlayerPhysicsComponent physics;
  private PlayerZappedHandler zappedHandler;

  #region Getters
  public PlayerWeaponComponent Weapon => weapon;
  public PlayerGroundComponent Ground => ground;
  public PlayerWalkComponent Walk => walk;
  public PlayerJumpComponent Jump => jump;
  public PlayerDashComponent Dash => dash;
  public PlayerDodgeComponent Dodge => dodge;
  public PlayerDI DI => di;
  #endregion

  void Awake() {
    physics = DI.Physics;
    zappedHandler = DI.Zapped;

    weapon.PlayerAwake(this);
    ground.PlayerAwake(this);
    walk.PlayerAwake(this);
    jump.PlayerAwake(this);
    dash.PlayerAwake(this);
    dodge.PlayerAwake(this);
  }

  void FixedUpdate() {
    if (zappedHandler.IsZapped()) {
      ZappedUpdate();
    } else {
      GameplayUpdate();
    }
  }

  private void ZappedUpdate() {
  }

  private void GameplayUpdate() {
    physics.PlayerFixedUpdate();
    weapon.PlayerFixedUpdate();
    ground.PlayerFixedUpdate();
    walk.PlayerFixedUpdate();
    jump.PlayerFixedUpdate();
    dash.PlayerFixedUpdate();
    dodge.PlayerFixedUpdate();
  }
}