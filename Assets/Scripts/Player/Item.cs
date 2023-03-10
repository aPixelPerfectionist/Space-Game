using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Item : MonoBehaviour {
    [Header("Design")]
        [SerializeField] float cooldown = 0.5f;
        [SerializeField] bool consumable = false;

    [Header("Design")]
        [SerializeField] Sprite sprite;

    public float GetCooldown() {return cooldown;}
    public bool IsConsumable() {return consumable;}
}
