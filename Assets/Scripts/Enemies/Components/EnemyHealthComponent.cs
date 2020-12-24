using UnityEngine;
using Common;
using Enums;


namespace Enemies.Components {
  public class EnemyHealthComponent : MonoBehaviour {

    [SerializeField]
    private float initialHP;

    [SerializeField]
    private MaterialTintColor materialTintColor;

    [SerializeField]
    private EnemyColliderComponent enemyColliderComponent;

    [SerializeField]
    private EmitDestructionItem emitDestructionItem;

    [SerializeField]
    private AudioSource hitSound;

    [SerializeField]
    private float smallHealth = 50f;
    [SerializeField]
    private float mediumHealth = 35f;
    [SerializeField]
    private float largeHealth = 15f;

    private float currentHP;
    private bool alreadyDestroyed = false;

    private void Awake() {
      currentHP = initialHP;
      enemyColliderComponent.OnTakeDamage += ReceiveDamage;
    }

    public string didDrop()
    {
      float roll = Random.value * 100;

      if (roll <= largeHealth)
      {
          return "large";
      } else if (roll <= mediumHealth)
      {
        return "medium";
      } else if(roll <= smallHealth)
      {
        return "small";
      }
      return "none";
    }

    public void ReceiveDamage(float damage, DamageType type) {
      currentHP = Mathf.Max(0, currentHP - damage);
      if (currentHP == 0) {
        if(!alreadyDestroyed)
        {
          string dropValue = this.didDrop();
          switch(dropValue)
          {
            case "small":
              HealthDropManager.Instance.SpawnSmall(enemyColliderComponent.transform.position);
              break;
            case "medium":
              HealthDropManager.Instance.SpawnNormal(enemyColliderComponent.transform.position);
              break;
            case "large":
              HealthDropManager.Instance.SpawnLarge(enemyColliderComponent.transform.position);
              break;
            default:
              break;
          }
          alreadyDestroyed = true;
          DestroyEnemy();
        }
      } else {
        hitSound.Play();
        materialTintColor.Flash();
      }
    }

    public void DestroyEnemy() {
      ExplosionsManager.Instance.SpawnNormal(transform.position, 0);
      emitDestructionItem.DestroyGameObject();
    }
  }
}