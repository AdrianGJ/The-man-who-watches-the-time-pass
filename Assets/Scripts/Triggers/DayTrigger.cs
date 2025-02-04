using UnityEngine;

public class DayTrigger : Trigger {
  public override void launchTrigger () {
    DayController.I.showDayLayout ();
    Destroy (gameObject);
  }
}