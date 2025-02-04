using TMPro;
using UnityEngine;

public class InteractionKey : MonoBehaviour {
  [HideInInspector]
  public static InteractionKey I;
  public TMP_Text text;

  private Interactable currentInteractable;
  void Awake () {
    I = this;
  }

  void Start () {
    gameObject.SetActive(false);
  }

  public void showInteraction (Interactable interactable) {
    gameObject.SetActive(true);
    text.text = interactable.interactionText;
    currentInteractable = interactable;
  }

  public void hideInteraction (){
    gameObject.SetActive(false);
    currentInteractable = null;
  }
}