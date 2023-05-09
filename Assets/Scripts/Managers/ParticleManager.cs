using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
     public static ParticleManager Instance {get; private set;}
     [SerializeField] ParticleSystem playerSparks;
     [SerializeField] GameObject playerThrusters;
     [SerializeField] GameObject playerPhasers;
     [SerializeField] ParticleSystem explosion;

      private void Awake() {
        if (Instance != null && Instance != this) { // ensure this is the only Instance
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public ParticleSystem GetPlayerSparks() {return playerSparks;}
    public GameObject GetPlayerThrusters() {return playerThrusters;}
    public GameObject GetPlayerPhasers() {return playerPhasers;}
}
