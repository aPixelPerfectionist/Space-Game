using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    [Header("Programming")]
        [SerializeField] Player player;

    GameObject spawn;
    Weapon weapon;
    Guard guard;
    Item item;

    float attackTime;
    float dodgeTime;
    float useTime;

    /*--------------------------------\
    | General Functions
    \================================*/
    void Awake() { // initialize Variables
        spawn = player.GetSpawn();
        weapon = player.GetWeapon();
        guard = player.GetGuard();
        item = player.GetItem();

        attackTime = weapon.GetCooldown() * -1;
        dodgeTime = guard.GetCooldown() * -1;
        if (item != null) {useTime = item.GetCooldown() * -1;}

        Physics2D.IgnoreLayerCollision(3, 7, true); // make enemies ignore the screen borders
        Physics2D.IgnoreLayerCollision(3, 8, true); // make projectiles ignore the screen borders
        Physics2D.IgnoreLayerCollision(8, 8, true); // make projectiles ignore each other
    }

    void FixedUpdate() { // takes care of anything that needs to be updated regularly
        if (Input.GetKey("z") && CanAttack()) {Attack();}
        if (Input.GetKey("x") && CanDodge()) {Dodge();}
        if (Input.GetKey("c") && CanUse()) {Use();}
        player.Move();
    }

    /*--------------------------------\
    | Actions
    \================================*/
    void Attack() { // spawns a bullet and creates a time stamp
        StartCoroutine(Fire(weapon.GetRate()));
        attackTime = Time.time;
    }

    void Dodge() { // executes the Guard Function and creates a time stamp
        dodgeTime = Time.time;
        player.Guard();
    }

    void Use() { // creates a time stamp
        useTime = Time.time;
        if (item.IsConsumable() == true) {item = null;}
    }

    /*--------------------------------\
    | Coroutines
    \================================*/
    IEnumerator Fire(float time) {
        for (int i = weapon.GetRounds(); i > 0; i--) {
            Projectile projectile = Instantiate<Projectile>(weapon.GetProjectile(), spawn.transform); // spawn projectile
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), player.GetComponent<Collider2D>()); // make it ignore the player
            yield return new WaitForSeconds(time);
        }
        
    }

    /*--------------------------------\
    | Flags
    \================================*/
    bool CanBeHit() { // check if the player can be damaged
        if (dodgeTime + guard.GetCooldown() < Time.time) {return false;}
        return false;
    }

    bool CanAttack() { // check if the player can attack
        if (attackTime + weapon.GetCooldown() < Time.time) {return true;}
        return false;
    }

    bool CanDodge() { // check if the player can dodge
        if (dodgeTime + guard.GetCooldown() < Time.time) {return true;}
        return false;
    }

    bool CanUse() { // check if the player can use items
        if (item != null && useTime + item.GetCooldown() < Time.time) {return true;}
        return false;
    }

    /*--------------------------------\
    | Misc
    \================================*/
    
}
