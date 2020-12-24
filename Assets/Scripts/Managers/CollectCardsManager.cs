using UnityEngine;
using System.Collections;
using Enums;
using System.Collections.Generic;
using Kite;

namespace Managers {
  public class CollectCardsManager : MonoBehaviour {

    public static CollectCardsManager Instance;

    [SerializeField]
    private AudioClip cardPickupSound;

    [SerializeField]
    private AudioClip cardCompletedSound;

    private readonly HashSet<CollectCards> cardsToPick = new HashSet<CollectCards> {
      CollectCards.Blue,
      CollectCards.Green,
      CollectCards.Pink,
      CollectCards.Purple,
      CollectCards.Red,
      CollectCards.Yellow,
    };

    public bool HasCard(CollectCards powerup) {
      return !cardsToPick.Contains(powerup);
    }

    public void OnCardObtained(CollectCards type) {
      cardsToPick.Remove(type);
      int cardsToPickLeft = cardsToPick.Count;
      if (cardsToPickLeft == 0) {
        AudioSingleton.PlaySound(cardCompletedSound);
        GameplayManager.Instance.GoToCredits();
      } else {
        AudioSingleton.PlaySound(cardPickupSound);
      }
    }

    private void Awake() {
      Instance = this;
    }
}
}