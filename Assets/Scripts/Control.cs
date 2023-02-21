using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    [Header("Programming")]
        [SerializeField] Player player;

    GameObject spawn;
    Weapon weapon;
    Item item;

    float attackTime = 0.0f;
    float dodgeTime = 0.0f;
    float useTime = 0.0f;

    /*--------------------------------\
    | General Functions
    \================================*/

    void Start() {
        spawn = player.GetSpawn();
        weapon = player.GetWeapon();
        item = player.GetItem();
    }

    void Update() {
        if (Input.GetKey("z") && CanAttack()) {Attack();}
        if (Input.GetKey("x") && CanDodge()) {Dodge();}
        if (Input.GetKey("c") && CanUse()) {Use();}
        player.Move();
    }

    /*--------------------------------\
    | Actions
    \================================*/
    void Attack() {
        Instantiate(weapon, spawn.transform.position, spawn.transform.rotation);
        attackTime = Time.time;
    }

    void Dodge() {
        dodgeTime = Time.time;
    }

    void Use() {
        useTime = Time.time;
        if (item.IsConsumable() == true) {item = null;}
    }

    /*--------------------------------\
    | Flags
    \================================*/
    bool CanAttack() {
        if (attackTime + weapon.GetCooldown() < Time.time) {return true;}
        return false;
    }

    bool CanDodge() {
        if (dodgeTime + player.GetDodge() < Time.time) {return true;}
        return false;
    }

    bool CanUse() {
        if (item != null && useTime + item.GetCooldown() < Time.time) {return true;}
        return false;
    }

}
