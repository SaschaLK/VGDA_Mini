using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour {

    public static GameManagerBehaviour instance;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
