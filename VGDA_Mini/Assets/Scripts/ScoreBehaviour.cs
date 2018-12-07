using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {

    //private float score;
    private Text score;

    private void Awake() {
        score = GetComponent<Text>();
    }

    private void Update() {
        score.text = "Score: " + Time.timeSinceLevelLoad.ToString();
    }

}
