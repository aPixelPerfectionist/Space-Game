using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    [SerializeField] float spawnTime = 5f;
    [SerializeField] GameObject wave;

    void Awake () {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(spawnTime);
        Instantiate<GameObject>(wave, transform);
    }
}
