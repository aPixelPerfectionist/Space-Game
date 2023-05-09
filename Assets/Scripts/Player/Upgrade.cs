using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Upgrade : MonoBehaviour {
    [SerializeField] Sprite sprite;
    [SerializeField] int price;

    bool owned = false;

    public string GetName() {return name;}
    public Sprite GetImage() {return sprite;}
    public int GetPrice() {return price;}

    public bool GetOwned() {return owned;}
    public void SetOwned(bool b) {owned = b;}
}
