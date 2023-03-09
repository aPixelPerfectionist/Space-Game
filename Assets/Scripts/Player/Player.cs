using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health;
        [SerializeField] Vector2 speed;
        Vector2 movement;
        bool canBeHit = true;

    [Header("Audio")]
        [SerializeField] AudioClip sfxHit;
        [SerializeField] AudioClip sfxDie;

    [Header("Equipment")]
        [SerializeField] Weapon weapon;
        [SerializeField] Guard guard;
        [SerializeField] Item item;

    [Header("Programming")]
        [SerializeField] GameObject spawn;

    AudioSource audioS;
    SpriteRenderer spriteR;
    Rigidbody2D rb2D;

    void Awake() { // Initialize Variables
        audioS = GetComponent<AudioSource>();
        spriteR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D hit) { // On Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // Check if it's a projectile
        if (projectile != null && projectile.HitsPlayer() && canBeHit) { // Check if it hits the player
            health -= projectile.GetDamage(); // Deal damage
            int piercing = projectile.GetPiercing();
            switch (piercing) { // Check if the projectile is piercing
                case -1: break; // If it has infinite pierce do nothing
                case 0: Destroy(projectile.gameObject); break; // If it has 0 destroy the projectile
                default: projectile.SetPiercing(piercing--); break; // Otherwise decrement by 1
            }
            if (health <= 0) {OnDie();}
            else {StartCoroutine(OnHit());}
        }
    }

    void OnDie() {
        if (sfxHit != null) {audioS.PlayOneShot(sfxHit, sfxHit.length);}
        SceneManager.LoadScene("Restart");
    }

    IEnumerator OnHit() {
        if (sfxHit != null) {audioS.PlayOneShot(sfxHit, sfxHit.length);}
        canBeHit = false;
        spriteR.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteR.color = Color.white;
        canBeHit = true;
    }

    IEnumerator OnGuard() {
        AudioClip sfx = guard.GetSFX();
        if (sfx != null) {audioS.PlayOneShot(sfx, sfx.length);}
        canBeHit = false;
        spriteR.color = Color.blue;
        yield return new WaitForSeconds(guard.GetDuration());
        spriteR.color = Color.white;
        canBeHit = true;
    }

    public void Move() {
        movement.x = Input.GetAxis("Horizontal") * speed.x;
        movement.y = Input.GetAxis("Vertical") * speed.y;
        rb2D.velocity = movement;
    }

    public void Guard() {
        StartCoroutine(OnGuard());
    }

    public Weapon GetWeapon() {return weapon;}
    public Guard GetGuard() {return guard;}
    public Item GetItem() {return item;}
    public GameObject GetSpawn() {return spawn;}

    public float GetHealth() {return health;}
    public Vector2 GetSpeed() {return speed;}
}
