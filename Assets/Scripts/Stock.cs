using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Stock : MonoBehaviour {
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] Image image;

    Upgrade upgrade;

    public Upgrade GetUpgrade() {return upgrade;}
    public void SetUpgrade(Upgrade u) {upgrade = u;}

    public TextMeshProUGUI GetLabel() {return label;}
    public void SetLabel(string s) {label.text = s;}

    public TextMeshProUGUI GetPrice() {return price;}
    public void SetPrice(int i) {price.text = i.ToString() + " Credits";}

    public void SetImage(Sprite i) {image.sprite = i;}
}
