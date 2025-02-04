using UnityEngine;

public class StoryTrigger : Trigger {
  public string textToShow;
  public override void launchTrigger () {
    TextLoader.I.showText(textToShow);
    gameObject.SetActive(false);
  }
}