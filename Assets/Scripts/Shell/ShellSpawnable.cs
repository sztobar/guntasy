using UnityEngine;
using System.Collections;

public class ShellSpawnable : MonoBehaviour {

  public ShellSpawnable Spawn() {
    return Spawn(transform.position, transform.rotation);
  }

  public ShellSpawnable Spawn(Vector2 position, Quaternion rotation) {
    var projectile = Instantiate(this, position, rotation);
    projectile.gameObject.SetActive(true);
    return projectile;
  }

}
