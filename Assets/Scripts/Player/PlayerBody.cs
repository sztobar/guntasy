using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  private Direction3Animator animator;

  // temporary di is serialized here
  [SerializeField]
  private PlayerDI di;

  private PlayerWeaponArm weaponArm;

  private void Awake() {
    Inject(di);
  }

  public void Inject(PlayerDI di) {
    animator = di.BodyAnimator;
    weaponArm = di.WeaponArm;
  }

  private void Update() {
    var direction = weaponArm.Weapon.GetDirection3();
    animator.SetDirection(direction);
  }
}
