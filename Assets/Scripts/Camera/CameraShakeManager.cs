using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour {

  public static CameraShakeManager Instance;

  [SerializeField]
  private CinemachineBrain cinemachineBrain;

  private CinemachineVirtualCamera cinemachineVirtualCamera;
  private CinemachineBasicMultiChannelPerlin cinemachinePerlin;
  private float shakeTimeLeft;

  public void Shake(float amount, float frequency, float duration) {
    GetCurrentVirtualCamera();
    cinemachinePerlin.m_AmplitudeGain = amount;
    cinemachinePerlin.m_FrequencyGain = frequency;
    shakeTimeLeft = duration;
  }

  private void GetCurrentVirtualCamera() {
    if (cinemachinePerlin) {
      cinemachinePerlin.m_AmplitudeGain = 0;
    }
    cinemachineVirtualCamera = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
    cinemachinePerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
  }

  private void Awake() {
    Instance = this;
  }

  private void Update() {
    if (shakeTimeLeft > 0) {
      shakeTimeLeft -= Time.deltaTime;
      if (shakeTimeLeft <= 0) {
        cinemachinePerlin.m_AmplitudeGain = 0;
      }
    }
  }
}
