using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour {
    public float heal;

    void OnTriggerEnter(Collider collider) {
        PlayerHP playerHP = collider.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null) {
            playerHP.Heal(this.heal);
            Destroy(this.gameObject);
        }
    }
}
