using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class ShopManager : MonoBehaviour {
    public static ShopManager Instance {get; private set;}
    [SerializeField] TextMeshProUGUI creditsText;

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this);
            return;
        }
        Instance = this;
        SetCredits(GameManager.Instance.GetCredits());
    }

    public void SetCredits(int i) {creditsText.text = i.ToString() + " Credits";}
}
