using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]
        [SerializeField] float damage;
        [SerializeField] float cooldown;
        [SerializeField] float speed;

    [Header("Programming")]
        [SerializeField] Projectile projectile;

    public float GetCooldown() {return cooldown;}
    public Projectile GetProjectile() {return projectile;}
}
