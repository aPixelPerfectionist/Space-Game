using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    [Header("General")]
        [SerializeField] AudioClip confirmSFX;
        [SerializeField] AudioClip cancelSFX;
        [SerializeField] AudioClip startSFX;
        [SerializeField] AudioClip toggleSFX;
    public void LoadScene(string sceneName) {SceneManager.LoadScene(sceneName);}
    public void Fullscreen() {Screen.fullScreen = !Screen.fullScreen;}
    public void ExitGame() {Application.Quit();}

    public void Pause() {
        if (Time.timeScale == 0f){Time.timeScale = 1f;}
        else {Time.timeScale = 0f;}
    }

    public void ConfirmSFX() {AudioManager.Instance.PlaySFX(confirmSFX);}
    public void CancelSFX() {AudioManager.Instance.PlaySFX(cancelSFX);}
    public void StartSFX() {AudioManager.Instance.PlaySFX(startSFX);}
    public void ToggleSFX() {AudioManager.Instance.PlaySFX(toggleSFX);}
}
