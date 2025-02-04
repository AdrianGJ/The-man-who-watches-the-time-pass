using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour {
  public AudioClip bells;
  public AudioClip birds;
  public AudioClip music;
  public AudioClip phone;

  public static Sound I;
  private AudioSource audioSource;

  private void Awake () {
    I = this;
    audioSource = GetComponent<AudioSource> ();
  }

  public void play (AudioClip clip, bool loop = false) {
    if (loop) {
      audioSource.clip = clip;
      audioSource.Play ();
    } else {
      audioSource.loop = true;
      audioSource.PlayOneShot (clip);
    }
  }

  public void stopLoop () {
    audioSource.loop = false;
    audioSource.Stop ();
  }

  public void playFinalMusic () {
    audioSource.clip = bells;
    audioSource.Play ();
    StartCoroutine (AudioFadeOut.FadeOut (audioSource, 5f));
    Invoke ("_playMusic", 5.1F);
  }

  private void _playMusic () {
    audioSource.clip = music;
    audioSource.volume = 0.7F;
    audioSource.Play ();
  }

  public static class AudioFadeOut {

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
      float startVolume = audioSource.volume;

      while (audioSource.volume > 0) {
        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

        yield return null;
      }

      audioSource.Stop ();
      audioSource.volume = startVolume;
    }

  }

}