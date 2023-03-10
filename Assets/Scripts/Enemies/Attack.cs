using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Attack : MonoBehaviour {
    [Header("Programming")]
        [SerializeField] Weapon weapon;

    [Header("Programming")]
        [SerializeField] GameObject spawn;

    float attackTime;

    void Awake() { // initialize Variables
        attackTime = weapon.GetCooldown() * -1;
    }

    void FixedUpdate() { // takes care of anything that needs to be updated regularly
        if (CanAttack()) {
            StartCoroutine(Fire(weapon.GetRate()));
            attackTime = Time.time;
        }
    }

    IEnumerator Fire(float time) {
        for (int i = weapon.GetRounds(); i > 0; i--) {
            Projectile projectile = Instantiate<Projectile>(weapon.GetProjectile(), spawn.transform); // spawn projectile
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>()); // make it ignore the enemy
            yield return new WaitForSeconds(time);
        }
    }

    bool CanAttack() { // check if the player can attack
        if (attackTime + weapon.GetCooldown() < Time.time) {return true;}
        return false;
    }
}
