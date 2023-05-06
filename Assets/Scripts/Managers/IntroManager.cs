using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
    public PlayableDirector director;
    void OnEnable() {director.stopped += OnPlayableDirectorStopped;}

    void OnPlayableDirectorStopped(PlayableDirector dir) {SceneManager.LoadScene("Main");}

    void OnDisable() {director.stopped -= OnPlayableDirectorStopped;}
}
