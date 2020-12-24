using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScriptableWeapon", fileName = "ScriptableWeapon")]
public class ScriptableWeapon : ScriptableObject {

  [SerializeField]
  private new string name;

  [SerializeField]
  private GunController weaponPrefab;

  [SerializeField]
  private Sprite pickupSprite;

  [SerializeField]
  [Tooltip("Bigger value means better chance to spawn")]
  private int spawnWeight;

  public string Name => name;
  public GunController WeaponPrefab => weaponPrefab;
  public Sprite PickupSprite => pickupSprite;
  public int SpawnWeight => spawnWeight;
}
