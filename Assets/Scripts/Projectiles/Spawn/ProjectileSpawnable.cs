using UnityEngine;
using System.Collections;

public class ProjectileSpawnable : MonoBehaviour {

  public ProjectileSpawnable Spawn() {
    return Spawn(transform.position, transform.rotation);
  }

  public ProjectileSpawnable Spawn(Vector2 position, Quaternion rotation) {
    var projectile = Instantiate(this, position, rotation);
    projectile.gameObject.SetActive(true);
    OnSpawn();
    return projectile;
  }

  public virtual void OnSpawn() { }
}
