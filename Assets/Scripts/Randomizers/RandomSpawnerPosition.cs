using UnityEngine;
using System.Collections;

public class RandomSpawnerPosition : MonoBehaviour {
  
  void Awake() {
    GetComponent<SpriteRenderer>().enabled = false;
  }
}
