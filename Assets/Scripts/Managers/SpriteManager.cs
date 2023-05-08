using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpriteManager : MonoBehaviour {
    [Header("Ship")]
        [SerializeField] Sprite shipBase;
        [SerializeField] Sprite shipPhase;
        [SerializeField] Sprite shipWhite;

    [Header("Portrait")]
        [SerializeField] Sprite faceNeutral;
        [SerializeField] Sprite faceBase;
        [SerializeField] Sprite faceHappy;
        [SerializeField] Sprite faceConfused;
        [SerializeField] Sprite faceGlowing;
        [SerializeField] List<Sprite> disconnected = new List<Sprite>();
}
