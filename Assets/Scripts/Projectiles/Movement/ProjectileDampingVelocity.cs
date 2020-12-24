using UnityEngine;
using System.Collections;
using Kite;

public class ProjectileDampingVelocity : BaseProjectileMovement {

  [SerializeField]
  private float startTileVelocity;

  [SerializeField]
  private float endTileVelocity;

  [SerializeField]
  private float damping;

  private float currentVelocity;
  private float velocityDampRef;

  private void Awake() {
    currentVelocity = startTileVelocity * TileHelpers.TILE_SIZE;
  }


  public override Vector2 GetVelocity() {
    currentVelocity = Mathf.SmoothDamp(currentVelocity, endTileVelocity * TileHelpers.TILE_SIZE, ref velocityDampRef, damping);
    return new Vector2(currentVelocity, 0);
  }
}
