using UnityEngine;

public class Clock : MonoBehaviour {
  public GameObject ravens;
  public Transform ravenDirection;
  public GameObject shadowRavens;
  public Transform shadowRavenDirection;
  public float ravenSpeed;

  public static Clock I;

  void Awake () {
    I = this;
  }

  public void launchRavens (bool souund = true) {
    Vector2 direction = (ravenDirection.transform.position - ravens.transform.position).normalized;
    ravens.GetComponent<Rigidbody2D> ().AddForce (direction * ravenSpeed);

    Sound.I.play(Sound.I.bells);

    Vector2 shadowDirection = (shadowRavenDirection.transform.position - shadowRavens.transform.position).normalized;
    shadowRavens.GetComponent<Rigidbody2D> ().AddForce (shadowDirection * ravenSpeed);
    Invoke ("resetRavens", 5);
  }

  private void resetRavens () {
    ravens.transform.position = Vector2.zero;
    ravens.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
    shadowRavens.transform.position = Vector2.zero;
    shadowRavens.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
  }

}