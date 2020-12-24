﻿using UnityEngine;
using System.Collections;

namespace Kite {
  public class MovingCollidable : MonoBehaviour, ICollidable {

    private Vector2 allowedMove;

    public Vector2 AllowedMove {
      get => allowedMove;
      set => allowedMove = value;
    }

    void ICollidable.ForceMoveInto(Transform moving, float collideDistance, Direction4 direction) {
    }

    float ICollidable.GetAllowedMoveInto(Transform wantsToMove, float collideDistance, Direction4 direction, Vector2 hitPoint) {
      if (allowedMove != Vector2.zero && allowedMove.HasValueInDirection(direction)) {
        float allowedDistance = Mathf.Abs(allowedMove[direction.ToVector2Index()]);
        return Mathf.Min(collideDistance, allowedDistance);
      }
      return 0;
    }
  }
}