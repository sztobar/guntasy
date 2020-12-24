using UnityEngine;
using Kite;
using Interactive;

public class HealthDropManager : MonoBehaviour
{
  public static HealthDropManager Instance;

  [SerializeField]
  private HealthPickup smallHealthPickup;
  [SerializeField]
  private HealthPickup mediumHealthPickup;
  [SerializeField]
  private HealthPickup largeHealthPickup;

  private void Awake()
  {
    Instance = this;
  }

  public void SpawnSmall(Vector2 position)
  {
    var healthPack = Instantiate(smallHealthPickup, position, Quaternion.identity);
  }

  public void SpawnNormal(Vector2 position)
  {
    var healthPack = Instantiate(mediumHealthPickup, position, Quaternion.identity);
  }

  public void SpawnLarge(Vector2 position)
  {
    var healthPack = Instantiate(largeHealthPickup, position, Quaternion.identity);
  }
}
