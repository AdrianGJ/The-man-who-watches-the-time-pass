using UnityEngine;

public class Story : MonoBehaviour {
  [HideInInspector]
  public static Story I;
  [HideInInspector]
  public int currentStoryPoint;

  public Interactable[] orderStory;

  public string[] launchTexts;
  public GameObject[] activeObjects;

  [Space (20)]

  public GameObject gameOverTrigger;

  void Awake () {
    I = this;
  }

  void Start () {
    orderStory[currentStoryPoint].gameObject.SetActive (true);
    DayController.I.showDayLayout();
  }

  public void interaction (Interactable interactable) {
    if (currentStoryPoint == orderStory.Length - 1) {
      gameOverTrigger.SetActive (true);
      orderStory[currentStoryPoint].gameObject.SetActive (false);
      interactable.gameObject.SetActive (false);
      if (launchTexts[currentStoryPoint] != "") {
        TextLoader.I.showText (launchTexts[currentStoryPoint]);
      }
      if (activeObjects[currentStoryPoint]) {
        activeObjects[currentStoryPoint].SetActive (true);
      }
      return;
    }

    if (interactable == orderStory[currentStoryPoint]) {
      interactable.gameObject.SetActive (false);
      if (launchTexts[currentStoryPoint] != "") {
        TextLoader.I.showText (launchTexts[currentStoryPoint]);
      }
      if (activeObjects[currentStoryPoint]) {
        activeObjects[currentStoryPoint].SetActive (true);
      }
      currentStoryPoint++;
      orderStory[currentStoryPoint].gameObject.SetActive (true);
    }
  }
}