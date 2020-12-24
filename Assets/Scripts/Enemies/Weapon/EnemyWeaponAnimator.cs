using UnityEngine;

namespace Enemies.Weapon {
  public class EnemyWeaponAnimator : MonoBehaviour {

    static readonly int StateHash = Animator.StringToHash("State");

    [SerializeField]
    private Animator animator;

    public void PlayIdle() {
      SetAnimatorState(State.Idle);
    }

    public void PlayShoot() {
      SetAnimatorState(State.Shoot);
    }

    private void SetAnimatorState(State state) {
      animator.SetInteger(StateHash, (int)state);
    }

    enum State {
      Idle = 1,
      Shoot = 2
    }
  }
}