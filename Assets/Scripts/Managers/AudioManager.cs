using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour { // audio library and player
    public static AudioManager Instance {get; private set;}

    [Header("BGM")]
        [SerializeField] AudioClip titleBGM;
        [SerializeField] AudioClip introBGM;
        [SerializeField] AudioClip mapBGM;
        [SerializeField] AudioClip battleBGM;
        [SerializeField] AudioClip eventBGM;
        [SerializeField] AudioClip shopBGM;
        [SerializeField] AudioClip bossBGM;
        [SerializeField] AudioClip restartBGM;
        [SerializeField] AudioClip creditsBGM;

    [Header("Programming")]
        [SerializeField] AudioSource audioBGM;
        [SerializeField] AudioSource audioSFX;

    List<AudioClip> playlist = new List<AudioClip>();

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this);
            return;
        }
        Instance = this;
        
        // play new BGM on Scene Load
        playlist = new List<AudioClip> {titleBGM, introBGM, mapBGM, battleBGM, eventBGM, shopBGM, restartBGM, creditsBGM};
        SceneManager.sceneLoaded += OnSceneLoaded;

        Reset();
    }

    void Reset() { // reset volume and unmute all
        audioBGM.mute = false;
        audioSFX.mute = false;
        audioBGM.volume = 1;
        audioSFX.volume = 1;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) { // play new BGM on Scene Load
        ChangeClip(playlist[scene.buildIndex]);
    }

    void OnDisable() { // unsubscribe from delegate when disabled
        SceneManager.sceneLoaded -= OnSceneLoaded;
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

    // play sfx clip
    public void PlaySFX(AudioClip clip) {audioSFX.PlayOneShot(clip, clip.length);}

    // get sfx source
    public AudioSource GetAudioSource() {return audioSFX;}
}
