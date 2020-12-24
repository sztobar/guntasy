using UnityEngine;
using Kite;
using System;

public class WeaponDirection3Handler : MonoBehaviour, IWeaponInjectable {

  [SerializeField]
  private float upDirectionAngle;

  [SerializeField]
  private float downDirectionAngle;

  private float currentAngle;
  private Direction3Animator weaponDirectionAnimator;
  private Direction3 weaponDirection = Direction3.Front;

  public void Inject(IWeaponDI di) {
    weaponDirectionAnimator = di.WeaponDirectionAnimator;
  }

  public Direction3 GetDirection3() { 
    return weaponDirection;
  }

  public void LookAt(Vector2 mousePosition) {
    Vector2 directionVector = mousePosition - (Vector2)transform.position;
    SetDirection(directionVector);
  }

  private void CurrentAngleEffects() {
    if (currentAngle > upDirectionAngle) {
      weaponDirection = Direction3.Up;
    } else if (currentAngle < downDirectionAngle) {
      weaponDirection = Direction3.Down;
    } else {
      weaponDirection = Direction3.Front;
    }
    weaponDirectionAnimator.SetDirection(weaponDirection);
  }

  public void Reset() {
    SetDirection(Vector2.right);
  }

  public void SetDirection(Vector2 directionVector) {
    if (transform.right.x > 0) {
      currentAngle = Vector2.SignedAngle(Vector2.right, directionVector.normalized);
    } else {
      currentAngle = Vector2.SignedAngle(directionVector.normalized, Vector2.left);
    }
    CurrentAngleEffects();
  }

  private void OnDrawGizmosSelected() {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, (Vector2)transform.position + (Vector2Extensions.DegreeToVector2(upDirectionAngle) * 25));
    Gizmos.DrawLine(transform.position, (Vector2)transform.position + (Vector2Extensions.DegreeToVector2(downDirectionAngle) * 25));
  }
}
