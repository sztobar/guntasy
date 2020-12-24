using UnityEngine;
using Player;

[ExecuteInEditMode]
public class WeaponPickup : BasePickup {

  [SerializeField]
  private ScriptableWeapon scriptableWeapon;

  [SerializeField]
  private SpriteRenderer spriteRenderer;

  [SerializeField]
  private WeaponHint hint;

  private ScriptableWeapon editorCachedScriptableWeapon;

  public ScriptableWeapon GetScriptableWeapon() {
    return scriptableWeapon;
  }

  public void SetScriptableWeapon(ScriptableWeapon newScriptableWeapon) {
    scriptableWeapon = newScriptableWeapon;
    spriteRenderer.sprite = scriptableWeapon.PickupSprite;
    hint.SetName(scriptableWeapon.Name);
  }

  protected override void OnPlayerEnterCollision(PlayerCollisionHandler collisionHandler) {
    hint.gameObject.SetActive(true);
    collisionHandler.CollidingWeaponPickup = this;
  }

  protected override void OnPlayerExitCollision(PlayerCollisionHandler collisionHandler) {
    hint.gameObject.SetActive(false);
    collisionHandler.CollidingWeaponPickup = null;
  }

  private void Awake() {
    SetScriptableWeapon(scriptableWeapon);
  }

  private void Update() {
    if (!Application.isPlaying) {
      if (scriptableWeapon && scriptableWeapon != editorCachedScriptableWeapon) {
        SetScriptableWeapon(scriptableWeapon);
        editorCachedScriptableWeapon = scriptableWeapon;
      }
    }
  }
}