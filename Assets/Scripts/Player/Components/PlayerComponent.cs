using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour {

  protected bool disabled;

  public abstract void PlayerAwake(PlayerGameplayController controller);

  public void PlayerFixedUpdate() {
    if (!disabled) {
      PlayerFixedUpdateImpl();
    }
  }

  protected abstract void PlayerFixedUpdateImpl();

  public virtual void PlayerDisable() {
    disabled = true;
  }

  public virtual void PlayerEnable() {
    disabled = false;
  }
}
