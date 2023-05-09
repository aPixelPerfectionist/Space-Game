using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Outcome : MonoBehaviour {
    [SerializeField] Sprite sprite;
    [SerializeField] string desc;

    public string GetName() {return name;}
    public Sprite GetSprite() {return sprite;}
    public string GetDesc() {return desc;}
}
