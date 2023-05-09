using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Upgrade : MonoBehaviour {
    [SerializeField] Sprite sprite;
    [SerializeField] int price;

    int owned = 0;

    public string GetName() {return name;}
    public Sprite GetImage() {return sprite;}
    public int GetPrice() {return price;}

    public int GetOwned() {return owned;}
    public void SetOwned(int i) {owned = i;}
}
