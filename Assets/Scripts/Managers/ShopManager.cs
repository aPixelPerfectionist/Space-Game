using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopManager : MonoBehaviour {
    public static ShopManager Instance {get; private set;}
    [Header("General")]
        [SerializeField] AudioClip buySFX;
        [SerializeField] List<Upgrade> upgrades = new List<Upgrade>();
    [Header("Programming")]
        [SerializeField] TextMeshProUGUI creditsText;
        [SerializeField] GameObject stockText;
        [SerializeField] List<Button> buttons = new List<Button>();

    List<Upgrade> items = new List<Upgrade>();
    int stock;

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this);
            return;
        }
        Instance = this;

        for (int i = 0; i < buttons.Count; i++) { // add Listeners and assign variables
            int x = i;
            items.Add(upgrades[i]);
            buttons[i].onClick.AddListener(delegate {OnClick(x, buttons[x]);} );
            buttons[i].GetComponent<Stock>().SetLabel(items[i].GetName());
            buttons[i].GetComponent<Stock>().SetPrice(items[i].GetPrice());
            buttons[i].GetComponent<Stock>().SetImage(items[i].GetImage());
        }

        stock = buttons.Count;
        Stock();
    }

    void Stock() { // recalculate stock and credits
        GetCredits(GameManager.Instance.GetCredits());
        for (int i = 0; i < items.Count; i++) {
            if (items[i].GetPrice() > GameManager.Instance.GetCredits()) {
                buttons[i].interactable = false;
                buttons[i].GetComponent<Stock>().GetLabel().color = Color.gray;
                buttons[i].GetComponent<Stock>().GetPrice().color = Color.gray;
            }
        }
    }

    void GetCredits(int i) {creditsText.text = i.ToString() + " Credits";}

    public void OnClick(int i, Button b) {
        AudioManager.Instance.PlaySFX(buySFX);
        GameManager.Instance.AddCredits(items[i].GetPrice() * -1);
        b.gameObject.SetActive(false);
        stock--;

        if (stock <= 0) {stockText.SetActive(true);}
        else {Stock();}
    }
}
