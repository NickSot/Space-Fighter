using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float ProjectileDuration = 5f;
    public float ProjectileVelocity = 15f;
    public float damage = 15f;
    
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * ProjectileVelocity;
        Destroy(gameObject, ProjectileDuration);
	}

    void OnCollisionEnter(Collision col) {
        Destroy(gameObject);
        if (col.gameObject.name != "TUES_PlayerShip")
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<AsteroidMovementController>().hp -= damage;
            }

            if (col.gameObject.CompareTag("EnemyShip")) {
                col.gameObject.GetComponent<EnemyShipMovementController>().hp -= damage;
            }
        }
    }
}
