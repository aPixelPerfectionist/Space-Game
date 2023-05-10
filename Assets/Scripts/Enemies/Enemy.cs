using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health = 5;
        [SerializeField] int creditsMin = 0;
        [SerializeField] int creditsMax = 0;

        [SerializeField] bool canBeHit = true;
        [SerializeField] bool asteroid = false;

        [SerializeField] bool explodeOnDeath = false;
        [SerializeField] bool explodeOnTouch = false;
        [SerializeField] Projectile explosion;

    [Header("Audio")]
        [SerializeField] AudioClip sfxHit;
        [SerializeField] AudioClip sfxDie;
        [SerializeField] AudioClip sfxInv;

    AudioSource audioS;
    SpriteRenderer spriteR;
    Rigidbody2D rb2D;

    float HITTIME = 0.1F; // time after being hit
    float DIETIME = 0.5F; // time after being killed

    void Awake() { // initialize Variables
        audioS = AudioManager.Instance.GetAudioSource();
        spriteR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D hit) { // called when a triggered collision occurs
        Projectile projectile = hit.gameObject.GetComponent<Projectile>();

        if ((explodeOnTouch) && (hit.gameObject.GetComponent<Player>() || hit.gameObject.GetComponent<Enemy>() )) {OnDie();}

        else if ( ( projectile != null && projectile.HitsEnemy() ) || (asteroid && projectile != null) ) { // check if it's a projectile
            if (canBeHit) {
                health -= projectile.GetDamage(); // take damage
                if (projectile.gameObject.GetComponent<Movement>() != null) {
                    Vector2 direction = projectile.gameObject.GetComponent<Movement>().GetDirection();
                    float knockback = projectile.GetKnockback();
                    rb2D.AddForce(new Vector2(direction.x * knockback, direction.y * knockback));
                }
                if (health <= 0) {OnDie();} // check if killed
                else {StartCoroutine(OnHit());} // Process being hit
            }
            else if (sfxInv != null) {audioS.PlayOneShot(sfxInv, sfxInv.length);}
            
            int piercing = projectile.GetPiercing();

            switch (piercing) { // check if the projectile is piercing
                case -1: break; // if it has infinite pierce do nothing
                case 0: Destroy(projectile.gameObject); break; // if it has 0 destroy the projectile
                default: projectile.SetPiercing(piercing--); break; // otherwise decrement by 1
            }
        }
        else if (hit.gameObject.GetComponent<Player>()) { // || hit.gameObject.GetComponent<Enemy>().IsAsteroid()
            if (canBeHit) {
                health--;
                if (health <= 0) {OnDie();} // check if killed
                else {StartCoroutine(OnHit());} // Process being hit
            }
            else if (sfxInv != null) {audioS.PlayOneShot(sfxInv, sfxInv.length);}
        }
    }

    IEnumerator OnHit() { // process being hit
        canBeHit = false;
        spriteR.color = Color.red;
        if (sfxHit != null) {audioS.PlayOneShot(sfxHit, sfxHit.length);}
        yield return new WaitForSeconds(HITTIME);
        canBeHit = true;
        spriteR.color = Color.white; // return to normal
    }

    public void OnDie() { // process being destroyed
        canBeHit = false;
        GameManager.Instance.AddCredits(Random.Range(creditsMin, creditsMax));
        spriteR.enabled = false;
        if (sfxDie != null) {audioS.PlayOneShot(sfxDie, sfxDie.length);}
        if (explodeOnDeath) {
            Projectile projectile = Instantiate<Projectile>(explosion, transform);
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>()); // make it ignore the enemy
        }
        Destroy(gameObject, DIETIME);
    }

    public bool IsAsteroid() {return asteroid;}
    public bool GetCanBeHit() {return canBeHit;}
    public void SetCanBeHit(bool b) {canBeHit = b;}
}
