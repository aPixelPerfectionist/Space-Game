using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {get; private set;}

    private void Awake() { // ensure this is the only Instance
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void Reset() {}

}
