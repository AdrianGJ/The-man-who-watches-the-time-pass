using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {
    public bool backwards = false;
    void Start () {
        if (backwards) {
            GetComponent<Animator> ().SetBool ("backwards", true);
        }
    }
}