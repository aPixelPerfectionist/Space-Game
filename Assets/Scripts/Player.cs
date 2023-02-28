using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health;
        [SerializeField] Vector2 speed;
        Vector2 movement;

    [Header("Equipment")]
        [SerializeField] Weapon weapon;
        [SerializeField] Guard guard;
        [SerializeField] Item item;

    [Header("Programming")]
        [SerializeField] GameObject spawn;
        [SerializeField] Rigidbody2D rb2D;

    void OnTriggerEnter2D(Collider2D hit) { // On Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // Check if it's a projectile
        if (projectile != null && projectile.HitsPlayer()) { // Check if it hits the player
            health -= projectile.GetDamage(); // Deal damage
            Destroy(projectile.gameObject); // Destroy the projectile
            if (health <= 0) {Destroy(gameObject);} // Destroy the player if health <= 0
        }
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
