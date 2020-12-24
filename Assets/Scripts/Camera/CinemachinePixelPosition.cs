using UnityEngine;
using Cinemachine;


[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
#if UNITY_2018_3_OR_NEWER
[ExecuteAlways]
#else
[ExecuteInEditMode]
#endif
public class CinemachinePixelPosition : CinemachineExtension {

  [SerializeField]
  private float pixelsPerUnit = 1;

  protected override void PostPipelineStageCallback(
      CinemachineVirtualCameraBase vcam,
      CinemachineCore.Stage stage, ref CameraState state, float deltaTime) {
    if (stage == CinemachineCore.Stage.Body) {
      Vector3 pos = state.FinalPosition;
      Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
      state.PositionCorrection += pos2 - pos;
    }
  }

  float Round(float x) {
    return Mathf.Round(x * pixelsPerUnit) / pixelsPerUnit;
  }
}
