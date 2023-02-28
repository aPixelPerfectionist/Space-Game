using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] Vector2 speed;
    [SerializeField] Vector2 direction;
    Vector2 movement;

    Rigidbody2D rb2D;

    void Awake() {rb2D = GetComponent<Rigidbody2D>();}

    void FixedUpdate() {
        Move();
    }

    void Move() {
        movement.x = direction.x * speed.x;
        movement.y = direction.y * speed.y;
        rb2D.velocity = movement;
    }
}
