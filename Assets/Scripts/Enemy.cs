using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health;

    void OnTriggerEnter2D(Collider2D hit) { // On Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // Check if it's a projectile
        if (projectile != null && projectile.HitsEnemy()) { // Check if it hits enemies
            health -= projectile.GetDamage(); // Deal damage
            Destroy(projectile.gameObject); // Destroy the projectile
            if (health <= 0) {Destroy(gameObject);} // Destroy the enemy if health <= 0
        }
    }
}
