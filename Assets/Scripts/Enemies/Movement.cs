using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] Vector2 speed = new Vector2(3f, 3f);
    [SerializeField] Vector2 direction = new Vector2(-1f, 0f);
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

    public Vector2 GetDirection() {return direction;}
}
