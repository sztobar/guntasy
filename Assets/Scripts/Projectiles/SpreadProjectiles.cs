using UnityEngine;

public class SpreadProjectiles : MonoBehaviour {

  [SerializeField]
  private float spreadRadius;

  [SerializeField]
  private ProjectileSpawnable[] projectiles;

  private void Awake() {
    int length = projectiles.Length;
    for (int i = 0; i < length; i++) {
      projectiles[i].transform.localRotation = Quaternion.Euler(0, 0, GetProjectileRotation(i, length));
    }
  }

  private float GetProjectileRotation(int i, int length) {
    float halfRadius = spreadRadius / 2f;
    float zRotation = Mathf.Lerp(0, spreadRadius, i / (length - 1f)) - halfRadius;
    return zRotation;
  }
  
}
