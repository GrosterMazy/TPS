using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public float delay;
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision collision) {
        Invoke("Explosion", this.delay);
    }

    private void Explosion() {
        Destroy(this.gameObject);
        GameObject explosion = Instantiate(this.explosionPrefab);
        explosion.transform.position = this.transform.position;
        
    }
}
