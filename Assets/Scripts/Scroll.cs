using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Scroll : MonoBehaviour {
    [SerializeField] Vector2 speed = new Vector2(1f, 1f);
    [SerializeField] Vector2 direction = new Vector2(-1f, 0f);
    [SerializeField] bool moveWithCam = false;

    Vector3 movement = new Vector3(0f, 0f, 0f);

    void Update() {
        movement.x = direction.x * speed.x * Time.deltaTime;
        movement.y = direction.y * speed.y * Time.deltaTime;
        transform.Translate(movement);

        if (moveWithCam) {Camera.main.transform.Translate(movement);}
    }
}
