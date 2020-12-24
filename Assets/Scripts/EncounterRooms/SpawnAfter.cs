using UnityEngine;
using System.Collections;
using System;

namespace EncounterRoom {

  [Serializable]
  public struct SpawnAfter {
    public float timeToSpawn;
    public EnemySpawner spawner;
  }
}