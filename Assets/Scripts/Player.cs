using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health;
        [SerializeField] Vector2 speed;
        Vector2 movement;
        bool canBeHit = true;

    [Header("Equipment")]
        [SerializeField] Weapon weapon;
        [SerializeField] Guard guard;
        [SerializeField] Item item;

    [Header("Programming")]
        [SerializeField] GameObject spawn;
        Rigidbody2D rb2D;
        SpriteRenderer sr;

    void Awake() { // Initialize Variables
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D hit) { // On Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // Check if it's a projectile
        if (projectile != null && projectile.HitsPlayer() && canBeHit) { // Check if it hits the player
            health -= projectile.GetDamage(); // Deal damage
            int piercing = projectile.GetPiercing();
            switch (piercing) { // Check if the projectile is piercing
                case -1: break; // If it has infinite pierce do nothing
                case 0: Destroy(projectile.gameObject); break; // If it has 0 destroy the projectile
                default: projectile.SetPiercing(piercing--); break; // Otherwise decrement by 1
            }
            if (health <= 0) {Destroy(gameObject);} // Destroy the player if health <= 0
            else {StartCoroutine(OnHit());}
        }
    }

    IEnumerator OnHit() {
        canBeHit = false;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sr.color = Color.white;
        canBeHit = true;
    }

    public void Move() {
        movement.x = Input.GetAxis("Horizontal") * speed.x;
        movement.y = Input.GetAxis("Vertical") * speed.y;
        rb2D.velocity = movement;
    }

    public Weapon GetWeapon() {return weapon;}
    public Guard GetGuard() {return guard;}
    public Item GetItem() {return item;}
    public GameObject GetSpawn() {return spawn;}

    public float GetHealth() {return health;}
    public Vector2 GetSpeed() {return speed;}
}
