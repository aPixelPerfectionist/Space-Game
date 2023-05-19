using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour { // returns to the main menu when the cutscene ends
    public PlayableDirector director;
    void OnEnable() {director.stopped += OnPlayableDirectorStopped;} // subscribe

    void OnPlayableDirectorStopped(PlayableDirector dir) {SceneManager.LoadScene("Main");} // return to main menu

    void OnDisable() {director.stopped -= OnPlayableDirectorStopped;} // unsubscribe
}
