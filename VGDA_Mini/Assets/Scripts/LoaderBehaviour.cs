using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBehaviour : MonoBehaviour {

    public GameObject gameManager;

    private void Awake() {
        if(GameObject.Find("GameManager(Clone)") == null) {
            Instantiate(gameManager);
        }
    }
}
