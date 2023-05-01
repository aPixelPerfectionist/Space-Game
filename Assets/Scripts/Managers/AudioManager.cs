using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }
    [SerializeField] AudioSource audioBGM;
    [SerializeField] AudioSource audioSFX;

    private void Awake() { // ensure this is the only Instance
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }

        Instance = this;
        Reset();        
    }

    void Reset() { // reset volume and unmute all
        audioBGM.mute = false;
        audioSFX.mute = false;
        audioBGM.volume = 1;
        audioSFX.volume = 1;
    }

    // change volume
    public void ChangeBGM(Slider vol) {audioBGM.volume = vol.value;}
    public void ChangeSFX(Slider vol) {audioSFX.volume = vol.value;}

    // mute/unmute
    public void MuteBGM() {audioBGM.mute = !audioBGM.mute;}
    public void MuteSFX() {audioSFX.mute = !audioSFX.mute;}

    // change bgm clip
    public void ChangeClip(AudioClip clip) {
        audioBGM.clip = clip;
        audioBGM.Play();
    }

    // get sfx source
    public AudioSource GetAudioSource() {return audioSFX;}
}
