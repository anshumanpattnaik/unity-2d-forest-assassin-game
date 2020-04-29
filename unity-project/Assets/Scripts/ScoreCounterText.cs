using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterText : MonoBehaviour
{   
    Text scoreTxt;
    public static int amount = 0;

    void Start() {
        scoreTxt = GetComponent<Text> ();
    }

    void Update() {
        scoreTxt.text = amount.ToString();
    }
}