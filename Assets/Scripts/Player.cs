using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Design")]
        public float moveSpeed = 5.0f; // Default 5.0f
        public float fireRate = 0.5f; // Default 0.5f

    [Header("Programming")]
    public GameObject weapon;
    public GameObject ammo;

    float moveX;
    float moveY;

    bool coolDown = false;

    // Is called 1/frame, should be switched to FixedUpdate if using physics
    void Update() {
        Move();
        if (Input.GetKey("z") && coolDown == false) {Fire();}
        if (Input.GetKey("x")) {Dodge();}
        if (Input.GetKey("x")) {Use();}
    }

    // Moves the player
    void Move() {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        transform.Translate(moveX, 0, 0);
        transform.Translate(0, moveY, 0);
    }

    // Spawns a bullet
    void Fire() {
        Instantiate(ammo, weapon.transform.position, weapon.transform.rotation);
        StartCoroutine(CoolDown());
    }

    // Does something
    void Dodge() {
        //
    }

    // Does something
    void Use() {
        //
    }

    // Limits the weapon fire rate
    public IEnumerator CoolDown() {
        coolDown = true;
        yield return new WaitForSeconds(fireRate);
        coolDown = false;
    }
}
