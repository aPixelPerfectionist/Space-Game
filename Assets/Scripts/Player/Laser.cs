using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField] GameObject beam;
    [SerializeField] GameObject impact;

    Vector2 dir = Vector2.right; // Sets the direction of the laser

    float max = 20f; // Limits the size of the laser
    float length;

    void Update () {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, max);
        if (hit.collider != null) { // On impact
            length = Vector2.Distance(hit.collider.transform.position, this.transform.position);
            impact.SetActive(true);
        }
        else {impact.SetActive(false);}
    }

    public bool GetBeam() {return beam;}
    public bool GetImpact() {return impact;}
}
