using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float damage;

    [SerializeField] int piercing; // -1 is infinite, 0 is no
    [SerializeField] int bouncing; // -1 is infinite, 0 is no

    [SerializeField] bool hitsEnemy;
    [SerializeField] bool hitsPlayer;

    int LIFETIME = 20;

    void Awake() {
        Destroy(gameObject, LIFETIME);
    }

    public float GetDamage() {return damage;}

    public int GetPiercing() {return piercing;}
    public void SetPiercing(int i) {piercing = i;}

    public int GetBouncing() {return bouncing;}
    public void SetBouncing(int i) {bouncing = i;}

    public bool HitsEnemy() {return hitsEnemy;}
    public bool HitsPlayer() {return hitsPlayer;}
}
