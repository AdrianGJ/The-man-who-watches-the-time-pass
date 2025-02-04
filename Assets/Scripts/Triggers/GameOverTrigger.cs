using UnityEngine;

public class GameOverTrigger : Trigger {

  public float cameraSpeed;
  public Player player;
  public Sprite sitPj;
  public Color endColor;
  public GameObject thanks;
  private bool activated = false;
  public override void launchTrigger () {
    Clock.I.launchRavens (false);
    Sound.I.playFinalMusic();
    Destroy (player.GetComponent<Animator> ());
    player.GetComponent<SpriteRenderer> ().sprite = sitPj;
    Destroy (player.shadow.GetComponent<Animator> ());
    player.shadow.GetComponent<SpriteRenderer> ().sprite = sitPj;
    Destroy (player);
    Invoke("startFinalAnimation", 3);
    Invoke("endGame", 40);
  }

  void startFinalAnimation () {
    activated = true;
  }

  void endGame () {
    Camera.main.backgroundColor = endColor;
    thanks.SetActive(true);
  }

  void Update () {
    if (activated) {
      Camera.main.transform.position += new Vector3 (0, cameraSpeed * Time.deltaTime, 0);
    }
  }
}