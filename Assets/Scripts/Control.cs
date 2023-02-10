using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    // Public Variables
    public float speed = 5.0f;
    public GameObject player;

    float moveX;
    float moveY;

    void Start() {
        //
    }

    void FixedUpdate() {
        SetMovement();
    }

    void SetMovement() {
        moveX = Input.GetAxis("Horizontal") * speed;
        moveY = Input.GetAxis("Vertical") * speed;
        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        player.transform.Translate(moveX, 0, 0);
        player.transform.Translate(0, moveY, 0);
    }
}
