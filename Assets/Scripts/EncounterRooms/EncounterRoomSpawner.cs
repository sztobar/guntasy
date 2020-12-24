using UnityEngine;
using System.Collections;
using System;
using Common;

namespace EncounterRoom {
  public class EncounterRoomSpawner : MonoBehaviour {

    [SerializeField]
    EnemySpawnWave[] enemyWaves;

    [SerializeField]
    [Tooltip("Time between waves spawn")]
    private float spawnDelay;


    private float timeLeft;
    private int activeWaveIndex;

    public Action OnRoomComplete { get; set; } = delegate { };

    public void Activate() {
      gameObject.SetActive(true);
      ActivateWave(0);
    }

    public void Deactivate() {
      gameObject.SetActive(false);
      foreach(var wave in enemyWaves) {
        wave.Deactivate();
      }
    }

    private void ActivateWave(int index) {
      enemyWaves[index].Activate();
      enemyWaves[index].OnWaveCompleted += OnWaveCompleted;
    }

    private void Update() {
      if (timeLeft > 0) {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
          ApplyNextWave();
        }
      }
    }

    private void OnWaveCompleted() {
      timeLeft = spawnDelay;
      if (timeLeft <= 0) {
        ApplyNextWave();
      }
    }

    void ApplyNextWave() {
      if (activeWaveIndex == enemyWaves.Length - 1) {
        OnRoomComplete();
      } else {
        activeWaveIndex++;
        ActivateWave(activeWaveIndex);
      }
    }
  }
}