using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]
        [SerializeField] float cooldown;

    [Header("Programming")]
        [SerializeField] Projectile projectile;

    public float GetCooldown() {return cooldown;}
    public Projectile GetProjectile() {return projectile;}
}
