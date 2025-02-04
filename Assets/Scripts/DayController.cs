using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour {
  public static DayController I;

  public GameObject[] days;
  public float timeAtFullAlpha;
  public float velocityToClear;
  public bool blockedByOverlay = false;
  public Player player;
  private float lerpColor;

  private int currentDay = 0;
  void Awake () {
    I = this;
  }

  public void showDayLayout () {
    days[currentDay].SetActive (true);
    blockedByOverlay = true;
    lerpColor = 1.01F;
    Invoke ("updateTransparency", timeAtFullAlpha);
    if (currentDay == 2) {
      player.speed = player.speed / 2;
    }
  }

  private void updateTransparency () {
    lerpColor = 0.99F;
  }

  void Update () {
    if (lerpColor > 1) return;
    if (lerpColor <= 0 && days[currentDay].activeSelf) {
      days[currentDay].SetActive (false);
      currentDay++;
      blockedByOverlay = false;
      lerpColor = 1.01F;
      return;
    }
    var image = days[currentDay].GetComponent<Image> ();
    image.color = Color.Lerp (Color.clear, Color.black, lerpColor);
    image.GetComponentInChildren<TMP_Text> ().color = Color.Lerp (Color.clear, Color.white, lerpColor);
    lerpColor -= Time.deltaTime * velocityToClear;
  }
}