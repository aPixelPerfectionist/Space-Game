using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [Header("General")]
        [SerializeField] float health = 5;
        [SerializeField] Vector2 speed = new Vector2(5f, 6f);
        Vector2 movement;
        float speedMod = 1f;
        bool canBeHit = true;

    [Header("Audio")]
        [SerializeField] AudioClip sfxHit;
        [SerializeField] AudioClip sfxDie;

    [Header("Equipment")]
        [SerializeField] Weapon weapon;
        [SerializeField] Guard guard;

    [Header("Programming")]
        [SerializeField] GameObject spawn;
        [SerializeField] Sprite sprite;

    AudioSource audioS;
    SpriteRenderer spriteR;
    Rigidbody2D rb2D;

    void Awake() { // initialize Variables
        audioS = AudioManager.Instance.GetAudioSource();
        spriteR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D hit) { // on Hit
        Projectile projectile = hit.gameObject.GetComponent<Projectile>(); // check if it's a projectile
        if (projectile != null && projectile.HitsPlayer() && canBeHit) { // check if it hits the player
            health -= projectile.GetDamage(); // deal damage
            BattleManager.Instance.SetHealth(health); // change health bar image
            int piercing = projectile.GetPiercing();
            switch (piercing) { // check if the projectile is piercing
                case -1: break; // if it has infinite pierce do nothing
                case 0: Destroy(projectile.gameObject); break; // if it has 0 destroy the projectile
                default: projectile.SetPiercing(piercing--); break; // otherwise decrement by 1
            }
            if (health <= 0) {StartCoroutine(OnDie());} // process dying if out of health
            else {StartCoroutine(OnHit());} // otherwise process being hit
        }
        else if (hit.gameObject.GetComponent<Enemy>() && canBeHit) { // check if it's an enemy
            health--; // take 1 damage
            BattleManager.Instance.SetHealth(health); // change health bar image
            if (health <= 0) {StartCoroutine(OnDie());} // process dying if out of health
            else {StartCoroutine(OnHit());} // otherwise process being hit
        }
    }

    IEnumerator OnDie() { // process dying
        if (sfxDie != null) {audioS.PlayOneShot(sfxDie, sfxDie.length);} // play death sfx
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceDisconnected(); // change portrait
        GameManager.Instance.Pause(); // delay before transfering to restart screen
        yield return new WaitForSecondsRealtime(2f);
        GameManager.Instance.Pause();
        SceneManager.LoadScene("Restart");
    }

    IEnumerator OnHit() { // process being hit
        if (sfxHit != null) {audioS.PlayOneShot(sfxHit, sfxHit.length);} // play hit sfx
        canBeHit = false; // invincibility frame
        spriteR.color = Color.red; // turn red
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceSurprised(); // change portrait
        yield return new WaitForSeconds(0.25f); // delay before returning everything to normal
        spriteR.color = Color.white;
        canBeHit = true;
        yield return new WaitForSeconds(0.5f);
        BattleManager.Instance.GetPortrait().sprite = SpriteManager.Instance.GetFaceBase();
    }

    IEnumerator OnGuard() { // process guarding
        AudioClip sfx = guard.GetSFX(); // play sfx
        if (sfx != null) {audioS.PlayOneShot(sfx, sfx.length);}
        canBeHit = false; // turn invincible
        Sprite temp = spriteR.sprite; // change sprite
        spriteR.sprite = sprite;
        yield return new WaitForSeconds(guard.GetDuration()); // delay before returning everything to normal
        spriteR.sprite = temp;
        canBeHit = true;
    }

    public void Move() { // move based on input
        movement.x = Input.GetAxis("Horizontal") * speed.x * speedMod;
        movement.y = Input.GetAxis("Vertical") * speed.y * speedMod;
        rb2D.velocity = movement;
    }

    public void Guard() {
        StartCoroutine(OnGuard());
    }

    public Weapon GetWeapon() {return weapon;}
    public Guard GetGuard() {return guard;}
    public GameObject GetSpawn() {return spawn;}

    public float GetHealth() {return health;}
    public void SetHealth(float f) {
        health = f;
        BattleManager.Instance.SetHealth(health);
    }

    public Vector2 GetSpeed() {return speed;}
    public void SetSpeed(float f) {speedMod = f;}
    public void AddSpeed(float f) {speedMod = 1 + f/10f;}
}
