using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovementController : MonoBehaviour {

    public float hp = 50;
    public GameObject explosion;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        

        if (hp <= 0)
        {
            Instantiate(explosion, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}
