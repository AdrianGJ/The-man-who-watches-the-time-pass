using UnityEngine;

public class ChangeHourTrigger : Trigger {
  public SpriteRenderer clock;
  public Sprite sprite;
  public override void launchTrigger () {
    clock.sprite = sprite;
    gameObject.SetActive(false);
  }
}