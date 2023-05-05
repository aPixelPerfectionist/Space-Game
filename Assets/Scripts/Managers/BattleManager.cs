using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public static BattleManager Instance {get; private set;}

    [SerializeField] Player player;

    [SerializeField] Image imgHealth;
    [SerializeField] Image imgCharge;
    [SerializeField] Image imgPortrait;

    GameObject spawn;
    Weapon weapon;
    Guard guard;

    private void Awake() { // ensure this is the only Instance
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }

        Instance = this;

        // initialize Variables
        spawn = player.GetSpawn();
        weapon = player.GetWeapon();
        guard = player.GetGuard();

        // set Collision
        Physics2D.IgnoreLayerCollision(3, 7, true); // make enemies ignore the screen borders
        Physics2D.IgnoreLayerCollision(3, 8, true); // make projectiles ignore the screen borders
        Physics2D.IgnoreLayerCollision(8, 8, true); // make projectiles ignore each other
    }

    public void SetHealth(float health) {imgHealth.fillAmount = Mathf.Clamp(health/5, 0, 1f);} // change health bar image
}
