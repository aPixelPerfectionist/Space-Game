using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("General")]
        // General Variables
        public int healthMax = 5;
        int healthNow = 5;

        // Movement Variables
        public float speedBase = 5.0f;
        public float speedFocus = 3.0f;

        float speed;
        float moveX;
        float moveY;

        // Cooldown Variables
        float attackRate;
        public float dodgeRate = 1.0f;
        float useRate;

        float attackTime = 0.0f;
        float dodgeTime = 0.0f;
        float useTime = 0.0f;

    [Header("Equipment")]
        public Weapon weapon;
        public Item item;

    [Header("Programming")]
        public GameObject spawn;

    void Start() {
        attackRate = weapon.cooldown;
        if (item != null) {useRate = item.cooldown;}
    }

    // Is called 1/frame, should be switched to FixedUpdate if using physics
    void Update() {
        if (Input.GetKey("z") && (attackTime + attackRate < Time.time)) {Attack();}
        if (Input.GetKey("x") && (dodgeTime + dodgeRate < Time.time)) {Dodge();}
        if (Input.GetKey("c") && (useTime + useRate < Time.time) && (item != null)) {Use();}
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
        Instantiate(weapon, spawn.transform.position, spawn.transform.rotation);
        attackTime = Time.time;
    }

    // Does something
    void Dodge() {
        dodgeTime = Time.time;
    }

    // Does something
    void Use() {
        useTime = Time.time;
        if (item.consumable == true) {item = null;}
    }
}
