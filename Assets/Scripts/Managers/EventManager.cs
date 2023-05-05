using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class EventManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] TextMeshProUGUI bodyText;
    [SerializeField] TextMeshProUGUI outText;
    [SerializeField] Image imgEvent;

    [SerializeField] List<Event> events = new List<Event>();

    void Start() {
        nameText.text = events[0].GetName();
        descText.text = events[0].GetDesc();
        bodyText.text = events[0].GetBody();
        imgEvent.sprite = events[0].GetImage();
    }
}
