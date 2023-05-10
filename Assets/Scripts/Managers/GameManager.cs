using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {get; private set;}

    float healthMax = 5f;
    float healthNow;

    int speed;
    int rounds;

    int credits;
    int stage;

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    /*speed = BattleManager.Instance.GetPlayer().GetSpeed();

        rounds = BattleManager.Instance.GetPlayer().GetWeapon().GetRounds();
        damage = BattleManager.Instance.GetPlayer().GetWeapon().GetDamage();
        knockback = BattleManager.Instance.GetPlayer().GetWeapon().GetKnockback();*/

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

    public int GetRounds() {return rounds;}

    public float GetHealthMax() {return healthMax;}
    public float GetHealthNow() {return healthNow;}
    public void SetHealth(float f) {healthNow = f;}

    public void Reset() {
	Time.timeScale = 1f;
        SetCredits(0);
        SetStage(0);

        healthMax = 5f;
        healthNow = 5f;

        BattleManager.Instance.GetPlayer().GetWeapon().GetProjectile().SetDamage(1f);
        rounds = 0;

        speed = 0;
        BattleManager.Instance.GetPlayer().SetSpeed(1f);
    }

    public void Upgrade(string s) {
        switch (s) {
            case "health":
                healthMax++;
                if ((healthNow + 1) > healthMax) {healthNow = healthMax;}
                else {healthNow++;}
                break;
            case "heal":
                healthNow = healthMax;
                break;
            case "credits":
                AddCredits(50);
                break;
            case "damage":
                BattleManager.Instance.GetPlayer().GetWeapon().GetProjectile().AddDamage(0.5f);
                break;
            case "rounds":
                rounds++;
                break;
            case "speed":
                speed++;
                BattleManager.Instance.GetPlayer().AddSpeed(speed * 1f);
                break;
            default:
                //
                break;
        }
    }
}
