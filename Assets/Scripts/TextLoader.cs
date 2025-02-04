using System.Collections.Generic;
using TMPro;
using UnityEngine;

class TextLoader : MonoBehaviour {

  public TextAsset textAsset;
  public GameObject storyUi;
  public static TextLoader I;

  public bool showingText = false;

  private int currentIndex = 0;
  private string currentTitle = "";
  private Dictionary<string, List<string>> texts;
  private TMP_Text textCanvas;

  void Awake () {
    I = this;
    textCanvas = storyUi.GetComponentInChildren<TMP_Text> ();
    texts = new Dictionary<string, List<string>> ();
  }

  void Start () {
    string[] splittedText = textAsset.text.Split ('\n');
    string currentBlock = "";
    foreach (string item in splittedText) {
      if (item == "") continue;
      if (item.StartsWith ("--")) {
        currentBlock = item.Replace ("--", "");
        texts.Add (currentBlock, new List<string> ());
      } else {
        texts[currentBlock].Add (item);
      }
    }
  }

  void Update () {
    if (showingText && Input.GetKeyDown (KeyCode.E)) {
      advanceText ();
    }
  }

  public void showText (string title) {
    showingText = true;
    currentIndex = 0;
    currentTitle = title;
    storyUi.SetActive (true);
    advanceText ();
  }

  private void advanceText () {
    if (currentIndex >= texts[currentTitle].Count) {
      storyUi.SetActive (false);
      currentTitle = "";
      showingText = false;
    } else {
      textCanvas.text = texts[currentTitle][currentIndex];
      currentIndex++;
    }
  }
}