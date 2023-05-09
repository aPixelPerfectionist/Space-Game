using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public void LoadScene(string sceneName) {SceneManager.LoadScene(sceneName);}
    public void ExitGame() {Application.Quit();}

    public void Pause() {
        if (Time.timeScale == 0f){Time.timeScale = 1f;}
        else {Time.timeScale = 0f;}
    }
}
