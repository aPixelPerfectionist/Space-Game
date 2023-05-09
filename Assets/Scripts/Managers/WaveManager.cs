using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour {
    [SerializeField] int waves = 5;

    [SerializeField] List<Wave> enemies = new List<Wave>();
    [SerializeField] List<Enemy> bosses = new List<Enemy>();
    [SerializeField] GameObject panel;

    void Awake() {
        if (!BattleManager.Instance.GetIsBoss()) { // spawn waves
            BattleManager.Instance.GetBackground().GetComponentInChildren<Scroll>().enabled = true;
            List<Wave> wave = enemies;
            StartCoroutine(Spawn(wave));
        }
        else { // spawn boss
            BattleManager.Instance.GetBackground().GetComponentInChildren<Scroll>().enabled = false;
            int r = Random.Range(0, bosses.Count-1);
            Instantiate<GameObject>(bosses[r].gameObject, gameObject.transform);
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

        // end level
        GameManager.Instance.Pause();
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceHappy();
        panel.SetActive(true);
    }
}