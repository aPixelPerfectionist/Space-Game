using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour {
    [Header("General")]
        [SerializeField] bool hitsEnemy;
        [SerializeField] bool hitsPlayer;
        bool canBeHit;

    [Header("Visual")]
        [SerializeField] Sprite spriteA;
        [SerializeField] Sprite spriteB;

    SpriteRenderer spriteR;
    Rigidbody2D rb2D;

    int count = 0;

    void Awake() { // initialize Variables
        spriteR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        canBeHit = GetComponent<Enemy>().GetCanBeHit();
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if ((hitsEnemy && hit.gameObject.GetComponent<Enemy>()) || (hitsPlayer && hit.gameObject.GetComponent<Player>()) ) {
            count ++;
            if (count == 1) {
                spriteR.sprite = spriteA;
                if (!canBeHit) {GetComponent<Enemy>().SetCanBeHit(true);}
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit) {
        if ((hitsEnemy && hit.gameObject.GetComponent<Enemy>()) || (hitsPlayer && hit.gameObject.GetComponent<Player>()) ) {
            count --;
            if (count == 0) {
                spriteR.sprite = spriteB;
                if (!canBeHit) {GetComponent<Enemy>().SetCanBeHit(false);}
            }
        }
    }
}
