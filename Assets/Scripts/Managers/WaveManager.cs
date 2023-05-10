using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class WaveManager : MonoBehaviour {
    [Header("General")]
        [SerializeField] int waves = 5;
        [SerializeField] List<Wave> enemies = new List<Wave>();
        [SerializeField] List<Enemy> bosses = new List<Enemy>();

    [Header("Rewards")]
        [SerializeField] List<Upgrade> upgrades = new List<Upgrade>();
        List<Upgrade> rewards = new List<Upgrade>();

    [Header("Programming")]
        [SerializeField] List<Button> buttons = new List<Button>();
        [SerializeField] GameObject panel;

    void Awake() {
        GameManager.Instance.AddCredits(0);
        if (!BattleManager.Instance.GetIsBoss()) { // spawn waves
            BattleManager.Instance.GetBackground().GetComponentInChildren<Scroll>().enabled = true;
            List<Wave> wave = enemies;
            StartCoroutine(Spawn(wave));
        }
        else { // spawn boss
            BattleManager.Instance.GetBackground().GetComponentInChildren<Scroll>().enabled = false;
            int r = Random.Range(0, bosses.Count-1);
            Instantiate<GameObject>(bosses[r].gameObject, gameObject.transform);

// skip Boss
            SceneManager.LoadScene("credits");
        }
    }

    IEnumerator Spawn(List<Wave> wave) {
        yield return new WaitForSeconds(3f); // delay
        
        for (int i = waves; i > 0; i--) {
            int r = Random.Range(0, i-1);            
            Instantiate<GameObject>(wave[r].gameObject, gameObject.transform);
            yield return new WaitForSeconds(wave[r].GetDuration());
            wave.RemoveAt(r);
        }

        yield return new WaitForSeconds(5f); // delay
        OnWin();
        
    }

    void OnWin() {
        GameManager.Instance.Pause();
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceHappy();
        panel.SetActive(true);

        rewards = upgrades;
        for (int i = 0; i < 2; i++) { // add Listeners and assign variables
            int x = i;
            buttons[i].onClick.AddListener(delegate {OnClick(x);} );
            buttons[i].GetComponent<Stock>().SetLabel(rewards[i].GetName());
            buttons[i].GetComponent<Stock>().SetImage(rewards[i].GetImage());
        }
    }

    public void OnClick(int i) {
        //
    }
}