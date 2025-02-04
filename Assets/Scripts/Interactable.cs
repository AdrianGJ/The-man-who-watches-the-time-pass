using UnityEngine;

public class Interactable : MonoBehaviour {
  public string interactionText;
  private bool inRange = false;
  private AudioSource audioSource;
  public AudioClip interactClip;

  private void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D (Collider2D other) {
    if (!other.CompareTag ("Player")) return;
    inRange = true;
    InteractionKey.I.showInteraction (this);
  }

  void OnTriggerExit2D (Collider2D other) {
    if (!other.CompareTag ("Player")) return;
    inRange = false;
    InteractionKey.I.hideInteraction ();
  }

  void Update () {
    if (inRange && Input.GetKeyDown (KeyCode.E)) {
      if (audioSource && interactClip) {
        Sound.I.play(interactClip);
      }
      Story.I.interaction(this);
    }
    if (audioSource && !audioSource.isPlaying){
      audioSource.Play();
    }
  }
}