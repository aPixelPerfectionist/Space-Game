using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.gameObject.GetComponent<Player>()) {LoadScene("Restart");}
    }
}
