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
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<AsteroidMovementController>().hp -= damage;
        }
        else if (col.gameObject.CompareTag("EnemyShip") && !gameObject.CompareTag("EnemyProjectile"))
        {
            col.gameObject.GetComponent<EnemyShipMovementController>().hp -= damage;
        }
        else if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyProjectile"))
        {
            col.gameObject.GetComponent<PlayerController>().hp -= damage;
        }
        

        Destroy(gameObject);
    }
}
