using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpriteManager : MonoBehaviour {
    public static SpriteManager Instance {get; private set;}
    [Header("Ship")]
        [SerializeField] Sprite shipBase;
        [SerializeField] Sprite shipPhase;
        [SerializeField] Sprite shipWhite;

    [Header("Portrait")]
        [SerializeField] Sprite faceNeutral;
        [SerializeField] Sprite faceBase;
        [SerializeField] Sprite faceHappy;
        [SerializeField] Sprite faceConfused;
        [SerializeField] Sprite faceSurprised;
        [SerializeField] Sprite faceGlowing;
        [SerializeField] List<Sprite> disconnected = new List<Sprite>();

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public Sprite GetFaceBase() {return faceBase;}
    public Sprite GetFaceHappy() {return faceHappy;}
    public Sprite GetFaceSurprised() {return faceSurprised;}
    public Sprite GetFaceGlowing() {return faceGlowing;}
}
