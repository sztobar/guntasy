using UnityEngine;

public class ExplosionAnimator : MonoBehaviour {

  private static readonly int AnimationSpeedHash = Animator.StringToHash("AnimationSpeed");

  [SerializeField]
  private Animator animator;

  [SerializeField]
  private EmitDestructionItem emitDestructionItem;

  [SerializeField]
  [Tooltip("Animation speed min multiply")]
  private float minMultiplier;

  [SerializeField]
  [Tooltip("Animation speed max multiply")]
  private float maxMultiplier;

  private void Awake() {
    float multiplier = GenerateMultiplier();
    SetMultiplier(multiplier);
  }

  public void SetMultiplier(float multiplier) {
    animator.SetFloat(AnimationSpeedHash, multiplier);
  }

  public void OnAnimationEnd() {
    emitDestructionItem.OnItemDestroy();
    Destroy(gameObject);
  }

  private float GenerateMultiplier() {
    float range = maxMultiplier - minMultiplier;
    float randomInRange = Random.value * range;
    return randomInRange + minMultiplier;
  }
}