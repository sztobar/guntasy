using Common;
using UnityEngine;

namespace EncounterRoom {
  public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private EmitDestructionItem enemyToSpawn;

    [SerializeField]
    [Tooltip("Timestamp in seconds")]
    private float spawnAt;

    private bool spawned;
    private float timeElapsed;

    private void Awake() {
      enemyToSpawn.gameObject.SetActive(false);
    }

    private void OnEnable() {
      timeElapsed = 0;
    }

    private void Update() {
      if (spawned) {
        return;
      }
      timeElapsed += Time.deltaTime;
      if (timeElapsed >= spawnAt) {
        SpawnEnemy();
      }
    }

    private void SpawnEnemy() {
      spawned = true;
      enemyToSpawn.gameObject.SetActive(true);
    }
  }
}