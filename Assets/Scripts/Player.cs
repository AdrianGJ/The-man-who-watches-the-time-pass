using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  public float speed;
  public GameObject shadow;

  public Camera mainCamera;

  private Vector3 movement;

  private AudioSource audioSource;
  private Animator anim;
  private Animator shadowAnim;
  private SpriteRenderer sprite;
  private SpriteRenderer shadowSprite;

  void Awake () {
    anim = GetComponent<Animator> ();
    shadowAnim = shadow.GetComponent<Animator> ();
    sprite = GetComponent<SpriteRenderer> ();
    shadowSprite = shadow.GetComponent<SpriteRenderer> ();
    audioSource = GetComponent<AudioSource> ();
  }

  void Update () {
    movement = Vector3.zero;

    if (Input.GetKey (KeyCode.W)) movement.y += 1;
    if (Input.GetKey (KeyCode.S)) movement.y -= 1;
    if (Input.GetKey (KeyCode.D)) movement.x += 1;
    if (Input.GetKey (KeyCode.A)) movement.x -= 1;

    RaycastHit2D hit = Physics2D.Raycast (transform.position + movement, movement, speed);

    if ((hit && hit.collider.CompareTag ("Wall")) || TextLoader.I.showingText || DayController.I.blockedByOverlay) {
      movement = Vector3.zero;
    }

    if (hit && hit.collider.CompareTag ("Teleporter")) {
      teleport (hit.collider.GetComponent<Teleporter> ());
    }

    if (hit && hit.collider.CompareTag ("StoryTrigger")) {
      hit.collider.GetComponent<Trigger> ().launchTrigger ();
    }

    bool isWalking = movement.x != 0 || movement.y != 0;
    anim.SetBool ("walking", isWalking);
    shadowAnim.SetBool ("walking", isWalking);

    if (movement.x != 0) {
      sprite.flipX = movement.x < 0;
      shadowSprite.flipX = movement.x < 0;
    }

    if (movement != Vector3.zero) {
      if (!audioSource.isPlaying) {
        audioSource.Play ();
      }
    } else {
      audioSource.Stop ();
    }
  }
  void FixedUpdate () {
    transform.position = transform.position + movement * speed;
  }

  void teleport (Teleporter teleporter) {
    transform.position = teleporter.playerPosition.position;
    mainCamera.transform.position = teleporter.cameraPosition.position;
    mainCamera.orthographicSize = teleporter.cameraSize;
    if (teleporter.clip) {
      Sound.I.play (teleporter.clip, true);
    } else {
      Sound.I.stopLoop ();
    }
  }
}