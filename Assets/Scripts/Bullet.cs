using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float lifetime;

    public float damage;

    void DestroyBullet() {
        Destroy(this.gameObject);
    }

    void Start() {
        Invoke("DestroyBullet", this.lifetime);
    }

    void OnCollisionEnter(Collision collider) {
        EnemyHP comp = collider.gameObject.GetComponent<EnemyHP>();
        if (comp != null) comp.DealDamage(this.damage);
        this.DestroyBullet();
    }

    void FixedUpdate() {
        this.transform.position += this.transform.forward * this.speed * Time.fixedDeltaTime;
    }
}
