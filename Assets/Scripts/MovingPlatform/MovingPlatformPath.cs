using UnityEngine;
using Cinemachine;
using System.Linq;

[ExecuteAlways]
public class MovingPlatformPath : MonoBehaviour {

  [SerializeField] private bool useSmoothPath;
  [SerializeField] private bool loop;
  [SerializeField] private float waitAtEnds;

  [SerializeField] private CinemachinePath straightPath;
  [SerializeField] private CinemachineSmoothPath smoothPath;

  private CinemachinePathBase currentPath;
  private bool cachedUseSmoothPath;
  private bool cachedLoop;

  public Vector2 GetPositionAtDistance(float distance) =>
    currentPath.EvaluatePositionAtUnit(distance, CinemachinePathBase.PositionUnits.Distance);

  public float PathLength() =>
    currentPath.PathLength;

  private void Awake() {
    currentPath = straightPath;
  }

  private void Update() {
    if (Application.isPlaying) {
      RuntimeUpdate();
    } else {
      EditorUpdate();
    }
  }

  private void RuntimeUpdate() {
  }

  private void EditorUpdate() {
    if (useSmoothPath != cachedUseSmoothPath) {
      cachedUseSmoothPath = useSmoothPath;
      ChangePathType(useSmoothPath);
    }
    if (loop != cachedLoop) {
      cachedLoop = loop;
      if (useSmoothPath) {
        smoothPath.m_Looped = loop;
      } else {
        straightPath.m_Looped = loop;
      }
    }
  }

  private void ChangePathType(bool useSmooth) {
    straightPath.gameObject.SetActive(!useSmooth);
    smoothPath.gameObject.SetActive(useSmooth);
    if (useSmooth) {
      smoothPath.m_Waypoints = straightPath.m_Waypoints
        .Select(waypoint =>
          new CinemachineSmoothPath.Waypoint { position = waypoint.position, roll = 0 }
        ).ToArray();
      straightPath.m_Waypoints = new CinemachinePath.Waypoint[0];
      currentPath = smoothPath;
      smoothPath.m_Looped = loop;
    } else {
      straightPath.m_Waypoints = smoothPath.m_Waypoints
        .Select(waypoint =>
          new CinemachinePath.Waypoint { position = waypoint.position, roll = 0, tangent = Vector3.zero }
        ).ToArray();
      smoothPath.m_Waypoints = new CinemachineSmoothPath.Waypoint[0];
      currentPath = straightPath;
      straightPath.m_Looped = loop;
    }
  }
}
