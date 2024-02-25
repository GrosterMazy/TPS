using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Speed;
    public float Lifetime;

    void DestroyBullet() {
        Destroy(this.gameObject);
    }

    void Start() {
        Invoke("DestroyBullet", this.Lifetime);
    }

    void OnCollisionEnter(Collision collider) {
        this.DestroyBullet();
    }

    void FixedUpdate() {
        this.transform.position += this.transform.forward * this.Speed * Time.fixedDeltaTime;
    }
}
