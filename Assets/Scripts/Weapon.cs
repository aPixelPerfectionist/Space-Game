using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]        
        [SerializeField] float rate; // attack rate
        [SerializeField] float cooldown; // attack cooldown

        [SerializeField] int rounds = 1; // projectiles spawned per attack
        //[SerializeField] int piercing = 0;

    [Header("Programming")]
        [SerializeField] Projectile projectile; // projectile to be spawned
        [SerializeField] ParticleSystem sparks; // particles to be spawned

    public int GetRounds() {return rounds;}
    public float GetRate() {return rate;}
    public float GetCooldown() {return cooldown;}
    public Projectile GetProjectile() {return projectile;}
    public ParticleSystem GetSparks() {return sparks;}
}
