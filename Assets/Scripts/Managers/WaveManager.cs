using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour {
    [SerializeField] float delay = 3f;
    [SerializeField] List<Wave> enemies = new List<Wave>();
    [SerializeField] GameObject panel;

    void Awake() {
        StartCoroutine(Spawn(enemies));
    }

    IEnumerator Spawn(List<Wave> waves) {
        yield return new WaitForSeconds(delay);
        foreach (Wave wave in waves) {
            Instantiate<GameObject>(wave.gameObject, gameObject.transform);
            yield return new WaitForSeconds(wave.GetDuration());
        }
        yield return new WaitForSeconds(15f);

        GameManager.Instance.Pause();
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceHappy();
        panel.SetActive(true);
    }
}