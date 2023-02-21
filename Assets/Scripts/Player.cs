using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health = 5.0f;
        [SerializeField] float speed = 5.0f;
        [SerializeField] float dodgeRate = 1.0f;

    [Header("Equipment")]
        [SerializeField] Weapon weapon;
        [SerializeField] Item item;

    [Header("Programming")]
        [SerializeField] GameObject spawn;

    public void Move() {
        float temp = Input.GetAxis("Horizontal") * speed;
        temp *= Time.deltaTime;
        transform.Translate(temp, 0, 0);

        temp = Input.GetAxis("Vertical") * speed;
        temp *= Time.deltaTime;
        transform.Translate(0, temp, 0);
    }

    public Weapon GetWeapon() {return weapon;}
    public Item GetItem() {return item;}
    public GameObject GetSpawn() {return spawn;}

    public float GetHealth() {return health;}
    public float GetSpeed() {return speed;}
    public float GetDodge() {return dodgeRate;}
}
