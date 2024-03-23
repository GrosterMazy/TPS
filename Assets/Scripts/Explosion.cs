using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float explosionSpeed;
    public float maxScale;
    public float damage;

    void Start() {
        this.transform.localScale = Vector3.zero;
    }

    void Update() {
        this.transform.localScale += Vector3.one * Time.deltaTime * this.explosionSpeed;
        if (this.transform.localScale.x > this.maxScale)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider) {
        PlayerHP playerHP = collider.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
            playerHP.DealDamage(this.damage);

        EnemyHP enemyHP = collider.gameObject.GetComponent<EnemyHP>();
        if (enemyHP != null)
            enemyHP.DealDamage(this.damage);
    }
}
