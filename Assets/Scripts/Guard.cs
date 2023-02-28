using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {
    [Header("Design")]
        [SerializeField] float cooldown = 5.0f;
        [SerializeField] float duration = 1.0f;

    public float GetCooldown() {return cooldown;}
    public float GetDuration() {return duration;}
}
