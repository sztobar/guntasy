using UnityEngine;
using Kite;

public class ExplosionSpawnable : MonoBehaviour {

  [SerializeField]
  private AudioClip explosionClip;

  [SerializeField]
  private ExplosionDamage explisionDamage;

  public ExplosionSpawnable Spawn(Vector2 position, float damage) {
    ExplosionSpawnable explosion = Instantiate(this, position, Quaternion.identity);
    explosion.gameObject.SetActive(true);
    explosion.explisionDamage.SetDamage(damage);
    if (damage > 0) {
      AudioSingleton.PlayUniqueSound(explosionClip);
    }
    return explosion;
  }
}
