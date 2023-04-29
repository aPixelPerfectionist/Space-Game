using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    [SerializeField] AudioSource audioBGM;
    [SerializeField] AudioSource audioSFX;

    void Awake() {
        audioBGM.mute = false;
        audioSFX.mute = false;
        audioBGM.volume = 1;
        audioSFX.volume = 1;
    }

    public void ChangeBGM(Slider vol) {audioBGM.volume = vol.value;}
    public void ChangeSFX(Slider vol) {audioSFX.volume = vol.value;}

    public void MuteBGM() {audioBGM.mute = !audioBGM.mute;}
    public void MuteSFX() {audioSFX.mute = !audioSFX.mute;}

    public void ChangeClip(AudioClip clip) {
        audioBGM.clip = clip;
        audioBGM.Play();
    }
}
