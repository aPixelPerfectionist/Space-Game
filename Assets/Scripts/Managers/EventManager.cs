using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class EventManager : MonoBehaviour {
    [Header("General")]
        [SerializeField] List<Event> events = new List<Event>();
    [Header("Programming")]
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI descText;
        [SerializeField] TextMeshProUGUI bodyText;
        [SerializeField] TextMeshProUGUI outText;
        [SerializeField] Image imgEvent;
        [SerializeField] List<Button> buttons = new List<Button>();

    List<Outcome> outcomes = new List<Outcome>();

    void Start() {
        nameText.text = events[0].GetName();
        descText.text = events[0].GetDesc();
        bodyText.text = events[0].GetBody();
        imgEvent.sprite = events[0].GetImage();

        outcomes = events[0].GetOutcomes();
        for (int i = 0; i < 3; i++) {
            if (outcomes[i] != null) {
                int x = i;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = outcomes[i].GetName();
                buttons[i].onClick.AddListener(delegate {OnClick(x);} );
            }
            else {buttons[i].gameObject.SetActive(false);}
        } 
    }

    public void OnClick(int i) {
        imgEvent.sprite = outcomes[i].GetSprite();
        outText.text = outcomes[i].GetDesc();
    }
}
