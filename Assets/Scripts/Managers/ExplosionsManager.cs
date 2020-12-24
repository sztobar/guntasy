using UnityEngine;
using Explosion;
using Kite;

public class ExplosionsManager : MonoBehaviour {

  public static ExplosionsManager Instance;

  [SerializeField]
  private ExplosionSpawnable normalExplosionPrefab;

  [SerializeField]
  private ExplosionSpawnable bigExplosionPrefab;

  [SerializeField]
  private AudioClip explosionClip;

  [SerializeField]
  private AudioClip shortExplosionClip;

  private void Awake() {
    Instance = this;
  }

  public void SpawnNormal(Vector2 position, float damage) {
    normalExplosionPrefab.Spawn(position, damage);
    //var explosion = Instantiate(normalExplosionPrefab, position, Quaternion.identity);
    //explosion.SetDamage(damage);
    //explosion.gameObject.SetActive(true);
    //if (damage > 0) {
    //  AudioSingleton.PlayUniqueSound(shortExplosionClip);
    //}
  }

  public void SpawnBig(Vector2 position, float damage) {
    bigExplosionPrefab.Spawn(position, damage);
    //var explosion = Instantiate(bigExplosionPrefab, position, Quaternion.identity);
    //explosion.SetDamage(damage);
    //explosion.gameObject.SetActive(true);
    //if (damage > 0) {
    //  AudioSingleton.PlayUniqueSound(explosionClip);
    //}
  }
}
