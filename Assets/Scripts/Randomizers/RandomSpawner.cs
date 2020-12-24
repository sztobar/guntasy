using UnityEngine;
using System.Collections;

namespace Randomizers {
  public class RandomSpawner : MonoBehaviour {

    private static readonly System.Random rng = new System.Random();

    [SerializeField]
    GameObject[] itemsToSpawn;

    [SerializeField]
    Transform[] positions;

    private void Awake() {
      SpawnItems();
    }

    void SpawnItems() {
      Transform[] positions = Shuffle(this.positions);
      GameObject[] itemsToSpawn = Shuffle(this.itemsToSpawn);
      int itemsLength = itemsToSpawn.Length;

      for (int i = 0; i < positions.Length; i++) {

        if (i == itemsLength) {
          break;
        }

        itemsToSpawn[i].transform.position = positions[i].position;
        itemsToSpawn[i].gameObject.SetActive(true);
      }
    }

    // shameless stack overflow copy-paste
    // https://stackoverflow.com/a/1262619
    T[] Shuffle<T>(T[] list) {
      // copy array as well copy-paste
      // https://stackoverflow.com/a/46070979
      int length = list.Length;
      T[] result = new T[length];
      System.Array.Copy(list, 0, result, 0, length);

      int n = length;
      while (n > 1) {
        n--;
        int k = rng.Next(n + 1);
        T value = result[k];
        result[k] = result[n];
        result[n] = value;
      }
      return result;
    }
  }
}