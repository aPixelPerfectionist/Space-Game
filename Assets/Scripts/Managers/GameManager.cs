using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    AudioManager audioManager;
    MenuManager menuManager;


    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }

        Instance = this;
        audioManager = GetComponentInChildren<AudioManager>();
        menuManager = GetComponentInChildren<MenuManager>();
    }

}
