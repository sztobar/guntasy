using UnityEngine;
using System.Collections;
using System;
using Common;

namespace EncounterRoom {
  public class EnemySpawnWave : MonoBehaviour {

    [SerializeField]
    private EmitItemsDestroyed emitItemsDestroyed;

    public Action OnWaveCompleted { get; internal set; }

    internal void Activate() {
      gameObject.SetActive(true);
    }

    private void Awake() {
      emitItemsDestroyed.OnAllItemsDestroyed += OnEnemiesWaveCompleted;
    }

    void OnEnemiesWaveCompleted() {
      OnWaveCompleted();
      Destroy(gameObject);
    }

    internal void Deactivate() {
      gameObject.SetActive(false);
    }
  }
}