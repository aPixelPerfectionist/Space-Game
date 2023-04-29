using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Persistant : MonoBehaviour {
    void Awake() {DontDestroyOnLoad(this.gameObject);}
}
