using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour { // Handles menu functions and sfx
    [Header("General")]
        [SerializeField] AudioClip confirmSFX;
        [SerializeField] AudioClip cancelSFX;
        [SerializeField] AudioClip startSFX;
        [SerializeField] AudioClip toggleSFX;

    public void LoadScene(string sceneName) {SceneManager.LoadScene(sceneName);}
    public void Fullscreen() {Screen.fullScreen = !Screen.fullScreen;}
    public void ExitGame() {Application.Quit();}

    public void Pause() { // pauses the game
        if (Time.timeScale == 0f){Time.timeScale = 1f;}
        else {Time.timeScale = 0f;}
    }

    public void Reset() { // resets the game on reload
        GameManager.Instance.Reset();
    }

// truly filthy code
    public void Upgrade(string s) {
        GameManager.Instance.Upgrade(s);
    }

    public void ConfirmSFX() {AudioManager.Instance.PlaySFX(confirmSFX);}
    public void CancelSFX() {AudioManager.Instance.PlaySFX(cancelSFX);}
    public void StartSFX() {AudioManager.Instance.PlaySFX(startSFX);}
    public void ToggleSFX() {AudioManager.Instance.PlaySFX(toggleSFX);}
}
