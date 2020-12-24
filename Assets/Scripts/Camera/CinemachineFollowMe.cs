using UnityEngine;
using System.Collections;
using Cinemachine;

public class CinemachineFollowMe : MonoBehaviour {

  void Awake() {
    var cameras = FindObjectsOfType<CinemachineVirtualCamera>();
    foreach(var camera in cameras) {
      camera.Follow = transform;
      camera.GetComponent<TargetImpulseListener>().SetTarget(transform);
    }
  }
}
