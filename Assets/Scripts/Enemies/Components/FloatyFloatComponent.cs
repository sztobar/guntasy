using UnityEngine;
using System.Collections;

namespace Enemies.Components {
  public class FloatyFloatComponent : MonoBehaviour {

    [SerializeField]
    private float amplitude;

    [SerializeField]
    private float frequency;

    public float GetFloatyFloatValue() {
      return Mathf.Sin(Time.time * frequency) * amplitude;
    }
  }
}