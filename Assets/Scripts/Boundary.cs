using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Boundary : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D hit) { // destroy objects that go out of bounds
        hit.gameObject.SetActive(false);
        Destroy(hit.gameObject);
    }
}
