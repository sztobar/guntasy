using UnityEngine;
using Kite;

public class PlayerDebugTrailComponent : PlayerComponent {

  [SerializeField]
  private float trailDuration = 1f;

  [SerializeField]
  private Color groundedColor = new Color32(200, 123, 52, 255); //brown

  [SerializeField]
  private Color fallingColor = Color.blue;

  [SerializeField]
  private Color jumpingColor = Color.green;

  [SerializeField]
  private Color wallSlideColor = Color.gray;

  [SerializeField]
  private Vector2 anchor;

  #region Dependencies
  private PlayerPhysicsComponent physics;
  private PlayerWallSlideComponent wallSlideComponent;
  #endregion

  private Vector2 previousPosition;

  private void Awake() {
    previousPosition = transform.position;
  }

  public override void PlayerAwake(PlayerGameplayController controller) {
    physics = controller.DI.Physics;
    //wallSlideComponent = controller.WallSlide;
  }

  protected override void PlayerFixedUpdateImpl() {
    Color trailColor;
    if (physics.IsGrounded) {
      trailColor = groundedColor;
    } else if (physics.Velocity.Y > 0) {
      trailColor = jumpingColor;
    } else if (wallSlideComponent.IsWallSliding) {
      trailColor = wallSlideColor;
    } else {
      trailColor = fallingColor;
    }
    Debug.DrawLine(previousPosition + anchor, (Vector2)transform.position + anchor, trailColor, trailDuration);

    previousPosition = transform.position;
  }
}
