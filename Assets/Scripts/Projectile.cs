using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float damage;
    [SerializeField] float knockback; // force
    [SerializeField] float lifetime; // -1 is infinite

    [SerializeField] int piercing; // -1 is infinite, 0 is no
    [SerializeField] int bouncing; // -1 is infinite, 0 is no

    [SerializeField] bool hitsEnemy;
    [SerializeField] bool hitsPlayer;

    Rigidbody2D rb2D;

    void Awake() {
        if (lifetime >= 0) {Destroy(gameObject, lifetime);}
    }

    public float GetDamage() {return damage;}
    public float GetKnockback() {return knockback;}

    public int GetPiercing() {return piercing;}
    public void SetPiercing(int i) {piercing = i;}

    public int GetBouncing() {return bouncing;}
    public void SetBouncing(int i) {bouncing = i;}

    public bool HitsEnemy() {return hitsEnemy;}
    public bool HitsPlayer() {return hitsPlayer;}
}
