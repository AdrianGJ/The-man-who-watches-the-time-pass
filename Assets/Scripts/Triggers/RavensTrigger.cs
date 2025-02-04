public class RavensTrigger : Trigger {
  public override void launchTrigger () {
    Clock.I.launchRavens();
    gameObject.SetActive(false);
  }
}