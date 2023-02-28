using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health;
        SpriteRenderer sr;

    void Awake() { // Initialize Variables
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D hit) { // On Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // Check if it's a projectile
        if (projectile != null && projectile.HitsEnemy()) { // Check if it hits enemies
            health -= projectile.GetDamage(); // Deal damage
            int piercing = projectile.GetPiercing();
            switch (piercing) { // Check if the projectile is piercing
                case -1: break; // If it has infinite pierce do nothing
                case 0: Destroy(projectile.gameObject); break; // If it has 0 destroy the projectile
                default: projectile.SetPiercing(piercing--); break; // Otherwise decrement by 1
            }

            if (health <= 0) {Destroy(gameObject);} // Destroy the enemy if health <= 0
            else {StartCoroutine(OnHit());}
        }
    }

    IEnumerator OnHit() {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sr.color = Color.white;
    }
}
