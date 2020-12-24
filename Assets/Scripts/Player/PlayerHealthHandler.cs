using UnityEngine;
using Common;
using Managers;

public class PlayerHealthHandler : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  public float maxHp;

  [SerializeField]
  public float maxArmor;

  [SerializeField]
  private FlashTintColorMaterial flashTintColorMaterial;

  [SerializeField]
  private float zapInvulnerableTime;

  private PlayerSoundHandler soundHandler;

  public float currentHP;
  public float currentArmor;

  public void Inject(PlayerDI di) {
    soundHandler = di.Sound;
  }

  public void Recover(float recover) {
    soundHandler.PlayHpGet();
    currentHP = Mathf.Min(currentHP + recover, maxHp);
  }

  public void GetArmor() {
    soundHandler.PlayHpGet();
    currentArmor = maxArmor;
  }

  public void ReceiveDamage(float damage, bool isZap) {
    soundHandler.PlayHit();
    if (isZap) {
      flashTintColorMaterial.StartFlash(zapInvulnerableTime);
    } else {
      flashTintColorMaterial.StartFlash();
    }
    float damageAfterArmor = TakeArmorDamage(damage);
    TakeHealthDamage(damageAfterArmor);
  }

  private void TakeHealthDamage(float damage) {
    currentHP -= damage;
    if (currentHP <= 0) {
      GameplayManager.Instance.GameOver();
    }
  }

  private float TakeArmorDamage(float damage) {
    float damageAfterArmor = damage;
    if (currentArmor > 0) {
      damageAfterArmor = Mathf.Max(damage - currentArmor, 0);
      currentArmor = Mathf.Max(currentArmor - damage, 0);
    }
    return damageAfterArmor;
  }

  internal bool IsVulnerable() {
    return !flashTintColorMaterial.IsFlashing;
  }

  private void Awake() {
    currentArmor = 0;
    currentHP = maxHp;
  }

  private void Update() {
    PlayerManager.Instance.HpPercentage = currentHP / maxHp;
    PlayerManager.Instance.ArmorPercentage = currentArmor / maxArmor;
  }
}
