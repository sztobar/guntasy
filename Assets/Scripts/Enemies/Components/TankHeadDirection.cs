using UnityEngine;
using System.Collections;

namespace Enemies.Components {
  public class TankHeadDirection : MonoBehaviour {

    [SerializeField]
    Sprite frontSprite;

    [SerializeField]
    Sprite backSprite;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    EnemyShootComponent shootComponent;

    private void Update() {
      Vector2 lookDirection = shootComponent.GetLookDirection();
      spriteRenderer.sprite = lookDirection.x > 0 ? backSprite : frontSprite;
    }

  }
}