using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float damage = 1f;
    [SerializeField] float knockback = 1f; // force
    [SerializeField] float lifetime = 20; // -1 is infinite

    [SerializeField] int piercing = 0; // -1 is infinite, 0 is no
    //[SerializeField] int bouncing = 0; // -1 is infinite, 0 is no

    [SerializeField] bool hitsEnemy = false;
    [SerializeField] bool hitsPlayer = false;

    Rigidbody2D rb2D;

    void Awake() {
        if (lifetime >= 0) {Destroy(gameObject, lifetime);}
    }

    public float GetDamage() {return damage;}
    public float GetKnockback() {return knockback;}

    public int GetPiercing() {return piercing;}
    public void SetPiercing(int i) {piercing = i;}

    //public int GetBouncing() {return bouncing;}
    //public void SetBouncing(int i) {bouncing = i;}

    public bool HitsEnemy() {return hitsEnemy;}
    public bool HitsPlayer() {return hitsPlayer;}
}
