using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour {

    public GameObject fireballPrefab;
    public Rigidbody grenadePrefab;
    public Transform hand;
    public Transform aim;
    public float grenadeThrowForce;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            hand.LookAt(aim.position);
            Instantiate(this.fireballPrefab, this.hand.position+this.hand.forward, this.hand.rotation);
        }
        if (Input.GetMouseButtonDown(1)) {
            hand.LookAt(aim.position);
            Rigidbody grenade = Instantiate(this.grenadePrefab);
            grenade.transform.position = this.hand.position+this.hand.forward;
            grenade.AddForce(this.hand.transform.forward * this.grenadeThrowForce);
        }
    }
}
