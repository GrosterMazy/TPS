using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    public float value = 100;

    public void DealDamage(float damage) {
        this.value -= damage;
        if (this.value <= 0) Destroy(this.gameObject);
    }
}
