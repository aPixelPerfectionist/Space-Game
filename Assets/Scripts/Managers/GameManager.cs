using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {get; private set;}

    int credits;
    int stage;

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void Pause() {
        if (Time.timeScale == 0f){Time.timeScale = 1f;}
        else {Time.timeScale = 0f;}
    }

    public int GetCredits() {return credits;}
    public void SetCredits(int i) {
        credits = i;
        if (BattleManager.Instance != null) {BattleManager.Instance.SetCredits(credits);}
    }
    public void AddCredits(int i) {
        credits += i;
        if (BattleManager.Instance != null) {BattleManager.Instance.SetCredits(credits);}
    }

    public int GetStage() {return stage;}
    public void SetStage(int i) {stage = i;}
    public void IncStage(int i) {stage += i;}

    public void Reset() {
        SetCredits(0);
        SetStage(0);
    }
}
