using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Design")]
        [SerializeField] float damage = 1.0f;
        [SerializeField] float cooldown = 0.5f;
        [SerializeField] float speed = 1.0f;

    [Header("Programming")]
        [SerializeField] Sprite sprite;

    public float GetCooldown() {return cooldown;}
}
