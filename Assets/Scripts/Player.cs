using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Design")]
        public float speedBase = 5.0f; // Default 5.0f
        public float speedFocus = 3.0f; // Default 3.0f

        public float attackRate = 0.5f; // Default 0.5f
        public float dodgeRate = 1.0f; // Default 1.0f
        public float useRate = 1.0f; // Default 1.0f

    [Header("Programming")]
    public GameObject weapon;
    public GameObject ammo;

    // Movement Variables
    float speed;
    float moveX;
    float moveY;

    // Cooldown Variables
    float attackTime = 0.0f;
    float dodgeTime = 0.0f;
    float useTime = 0.0f;

    // Is called 1/frame, should be switched to FixedUpdate if using physics
    void Update() {
        if (Input.GetKey("z") && (attackTime + attackRate < Time.time)) {Attack();}
        if (Input.GetKey("x") && (dodgeTime + dodgeRate < Time.time)) {Dodge();}
        if (Input.GetKey("c") && (useTime + useRate < Time.time)) {Use();}
        Move();
    }

    // Moves the player
    void Move() {
        if (Input.GetKey(KeyCode.LeftShift)) {speed = speedFocus;}
        else {speed = speedBase;}

        moveX = Input.GetAxis("Horizontal") * speed;
        moveY = Input.GetAxis("Vertical") * speed;
        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        transform.Translate(moveX, 0, 0);
        transform.Translate(0, moveY, 0);
    }

    // Spawns a bullet
    void Attack() {
        Instantiate(ammo, weapon.transform.position, weapon.transform.rotation);
        attackTime = Time.time;
    }

    // Does something
    void Dodge() {
        dodgeTime = Time.time;
    }

    // Does something
    void Use() {
        useTime = Time.time;
    }
}
