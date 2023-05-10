using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]        
        [SerializeField] float rate;
        [SerializeField] float cooldown;

        [SerializeField] int rounds = 1;
        [SerializeField] int piercing = 0;

    [Header("Programming")]
        [SerializeField] Projectile projectile;
        [SerializeField] ParticleSystem sparks;

    public int GetRounds() {return rounds;}
    public float GetRate() {return rate;}
    public float GetCooldown() {return cooldown;}
    public Projectile GetProjectile() {return projectile;}
    public ParticleSystem GetSparks() {return sparks;}
}
