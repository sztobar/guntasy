using UnityEngine;
using UnityEngine.UI;
using Managers;
using Enums;

namespace UI.Gameplay {
  public class CollectCardUI : MonoBehaviour {

    [SerializeField]
    CollectCards type;

    Image uiImage;
    private bool hasCard;

    private void Update() {
      if (!hasCard && CollectCardsManager.Instance.HasCard(type)) {
        hasCard = true;
        Color imageColor = uiImage.color;
        imageColor.a = 1;
        uiImage.color = imageColor;
      }
    }

    private void Awake() {
      uiImage = GetComponent<Image>();
      Color imageColor = uiImage.color;
      imageColor.a = 0.3f;
      uiImage.color = imageColor;
    }
  }
}