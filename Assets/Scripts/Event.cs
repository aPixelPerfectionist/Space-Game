using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Event : MonoBehaviour {
    [Header("General")]
        [SerializeField] string eventName;
        [SerializeField] string eventDesc;
        [SerializeField] string eventBody;
        [SerializeField] Sprite eventImage;

    //[Header("Outcomes")]

    public string GetName() {return eventName;}
    public string GetDesc() {return eventDesc;}
    public string GetBody() {return eventBody;}
    public Sprite GetImage() {return eventImage;}
}
