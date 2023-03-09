using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]
        [SerializeField] int rounds = 1;
        [SerializeField] float rate;
        [SerializeField] float cooldown;

    [Header("Programming")]
        [SerializeField] Projectile projectile;

    public int GetRounds() {return rounds;}
    public float GetRate() {return rate;}
    public float GetCooldown() {return cooldown;}
    public Projectile GetProjectile() {return projectile;}
}
