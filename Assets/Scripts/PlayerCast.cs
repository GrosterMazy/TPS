using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour {

    public GameObject fireballPrefab;
    public Transform hand;
    public Transform aim;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            hand.LookAt(aim.position);
            Instantiate(this.fireballPrefab, this.hand.position+this.hand.forward, this.hand.rotation);
        }
    }
}
