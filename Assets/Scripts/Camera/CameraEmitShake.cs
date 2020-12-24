using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraEmitShake : MonoBehaviour {

  [SerializeField]
  private CinemachineImpulseSource impulseSource;

  [SerializeField]
  private Vector3 m_ImpulseVelocity;

  public void EmitShake(Vector3 position) {
    impulseSource.GenerateImpulseAt(position, m_ImpulseVelocity);
  }
}
