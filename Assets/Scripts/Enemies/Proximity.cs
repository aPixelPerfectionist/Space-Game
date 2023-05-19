using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Proximity : MonoBehaviour {
    [Header("General")]
        [SerializeField] float timer = 1f;
        [SerializeField] float speed = 1f;
        [SerializeField] bool timed = false;
        [SerializeField] bool hitsEnemy = true;
        [SerializeField] bool hitsPlayer = true;
        [SerializeField] bool homing = false;

    [Header("Visual")]
        [SerializeField] Sprite spriteA;
        [SerializeField] Sprite spriteB;

    SpriteRenderer spriteR;
    Rigidbody2D rb2D;
    Transform target;

    bool canBeHit;
    bool triggered = false;

    int count = 0;

    void Awake() { // initialize Variables
        spriteR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        canBeHit = GetComponent<Enemy>().GetCanBeHit();
        target = BattleManager.Instance.GetPlayer().gameObject.GetComponent<Transform>();
    }

    void FixedUpdate() { // if triggered, move towards the player
        if (triggered && homing) {transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);}
    }

    void OnTriggerEnter2D(Collider2D hit) { // process colliders getting close
        if ((hitsEnemy && hit.gameObject.GetComponent<Enemy>()) || (hitsPlayer && hit.gameObject.GetComponent<Player>()) ) { // check if target is valid
            if (homing && !triggered) {triggered = true;} // trigger homing enemies
            if (timed) {StartCoroutine(OnExplode());} // begin explosion countdown
            count ++; // track number of targets in range
            if (count == 1) { // update sprite and invincibility
                spriteR.sprite = spriteA;
                if (!canBeHit) {GetComponent<Enemy>().SetCanBeHit(true);}
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit) { // process colliders going away
        if ((hitsEnemy && hit.gameObject.GetComponent<Enemy>()) || (hitsPlayer && hit.gameObject.GetComponent<Player>()) ) {
            count --; // track number of targets in range
            if (count == 0) { // if no targets are in range
                if (homing) { // stop homing
                    spriteR.sprite = spriteB;
                    triggered = false;
                }
                if (!canBeHit) {GetComponent<Enemy>().SetCanBeHit(false);} // become invulnerable
            }
        }
    }

    IEnumerator OnExplode() { // process explosion
        yield return new WaitForSeconds(timer);
        rb2D.isKinematic = true;
        GetComponent<Enemy>().OnDie();

    }
}
