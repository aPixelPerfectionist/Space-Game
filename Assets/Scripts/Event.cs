using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Event : MonoBehaviour {
    [SerializeField] string desc;
    [SerializeField] string body;
    [SerializeField] Sprite image;

    [SerializeField] List<Outcome> outcomes = new List<Outcome>();

    public string GetName() {return name;}
    public string GetDesc() {return desc;}
    public string GetBody() {return body;}

    public Sprite GetImage() {return image;}
    public List<Outcome> GetOutcomes() {return outcomes;}
}
