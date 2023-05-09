using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class BattleManager : MonoBehaviour {
    public static BattleManager Instance {get; private set;}

    [SerializeField] Player player;

    [SerializeField] Image imgHealth;
    [SerializeField] Image imgCharge;
    [SerializeField] Image imgPortrait;

    [SerializeField] TextMeshProUGUI creditsText;

    GameObject spawn;
    Weapon weapon;
    Guard guard;

    float phaseTime;

    bool canAttack = true;
    bool canPhase = true;

    private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
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

// dirty code
        phaseTime = (guard.GetCooldown() + guard.GetDuration()) * -1;
    }

    private void FixedUpdate() {
        // process Input
        if (Input.GetKey("z") && canAttack) {StartCoroutine(Attack(weapon.GetRate()));}
        if (Input.GetKey("x") && canPhase) {StartCoroutine(Phase());}
        player.Move();

// dirty code
        imgCharge.fillAmount = Mathf.Clamp((phaseTime + guard.GetCooldown() + guard.GetDuration() - Time.time)/guard.GetCooldown(), 0, 1f);
    }

    /*--------------------------------\
    | Coroutines
    \================================*/
    private IEnumerator Attack(float time) {
        canAttack = false;
        ParticleManager.Instance.GetPlayerSparks().Play();
        for (int i = weapon.GetRounds(); i > 0; i--) {
            Projectile projectile = Instantiate<Projectile>(weapon.GetProjectile(), spawn.transform); // spawn projectile
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), player.GetComponent<Collider2D>()); // make it ignore the player
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(weapon.GetCooldown());
        canAttack = true;
    }

    private IEnumerator Phase() {
        player.Guard();
        phaseTime = Time.time;
        canPhase = false;

        // make enemies/bullets pass through the player while phasing
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(6, 8, true);

        // change the player's portrait while phasing
        ParticleManager.Instance.GetPlayerThrusters().SetActive(false);
        ParticleManager.Instance.GetPlayerPhasers().SetActive(true);
        imgPortrait.sprite = SpriteManager.Instance.GetFaceGlowing();
        yield return new WaitForSeconds(guard.GetDuration());
        imgPortrait.sprite = SpriteManager.Instance.GetFaceBase();
        ParticleManager.Instance.GetPlayerPhasers().SetActive(false);
        ParticleManager.Instance.GetPlayerThrusters().SetActive(true);

        // make enemies/bullets hit the player while not phasing
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Physics2D.IgnoreLayerCollision(6, 8, false);

        yield return new WaitForSeconds(guard.GetCooldown());
        canPhase = true;
    }

    /*--------------------------------\
    | Misc
    \================================*/
    public void SetHealth(float health) {imgHealth.fillAmount = Mathf.Clamp(health/5, 0, 1f);} // change health bar image
    public void SetCredits(int i) {creditsText.text = i.ToString();}
    public Image GetPortrait() {return imgPortrait;}
}
