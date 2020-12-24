using UnityEngine;
using Kite;

public class PlayerGroundComponent : PlayerComponent {

  #region dependencies
  private PlayerPhysicsComponent physics;
  #endregion

  private float previousFallSpeed;
  private bool wasGrouded;

  public delegate void LandDelegate(float fallSpeed);
  public LandDelegate OnLand { get; set; } = delegate { };

  public bool IsGrounded { get; set; }

  public override void PlayerAwake(PlayerGameplayController controller) {
    physics = controller.DI.Physics;
  }

  protected override void PlayerFixedUpdateImpl() {
    IsGrounded = physics.IsGrounded;

    if (IsGrounded && !wasGrouded) {
      OnLand(-previousFallSpeed);
    }
    SaveCurrentFrameValues();
  }

  private void SaveCurrentFrameValues() {
    previousFallSpeed = physics.Velocity.Y;
    wasGrouded = IsGrounded;
  }
}
