using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
    [SerializeField] List<Image> stages = new List<Image>();

    void Start() {
        GameManager.Instance.IncStage(1);
        for (int i = 0; i < stages.Count; i++) {stages[i].sprite = SpriteManager.Instance.GetStageBase();}
        for (int i = 0; i < GameManager.Instance.GetStage(); i++) {stages[i].sprite = SpriteManager.Instance.GetStageDone();}
    }

    public void NextScene() {
        switch (GameManager.Instance.GetStage()) {
            case 1:
                SceneManager.LoadScene("event");
                break;
            case 2:
                SceneManager.LoadScene("battle");
                break;
            case 3:
                SceneManager.LoadScene("shop");
                break;
            case 4:
                BattleManager.Instance.SetIsBoss(true);
                SceneManager.LoadScene("battle");
                break;
            default:
                SceneManager.LoadScene("battle");
                break;
        }
    }
}
