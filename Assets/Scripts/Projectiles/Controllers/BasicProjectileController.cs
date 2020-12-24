using UnityEngine;

public class BasicProjectileController : MonoBehaviour {

  [SerializeField]
  private BaseCollisionEmitter collisionEmitter;

  [SerializeField]
  private EmitDestructionItem emitDestructionItem;

  [SerializeField]
  private BaseProjectilePiercing projectilePiercing;

  [SerializeField]
  private BaseProjectileMovement projectileMovement;

  public void HandleCharacterCollision(RaycastHit2D hit) {
    if (projectilePiercing.Inflict(hit)) {
      emitDestructionItem.DestroyGameObject();
    }
  }

  public void HandleTileCollision(RaycastHit2D hit) {
    emitDestructionItem.DestroyGameObject();
  }

  private void Awake() {
    collisionEmitter.OnCollision += HandleCollision;
  }

  private void HandleCollision(RaycastHit2D hit, CollisionType type) {
    switch (type) {
      case CollisionType.Tile:
        HandleTileCollision(hit);
        break;
      case CollisionType.Character:
        HandleCharacterCollision(hit);
        break;
    }
  }

  void FixedUpdate() {
    transform.Translate(projectileMovement.GetVelocity() * Time.deltaTime);
    collisionEmitter.Cast();
  }
}
