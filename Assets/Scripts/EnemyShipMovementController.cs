using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShipMovementController : MonoBehaviour {

    public float hp = 50;
    public GameObject explosion;

    GameObject player = null;

    // Use this for initialization
    void Start() {

    }

    public void RegisterPlayer(GameObject obj) {
        player = obj;
    }

    // Update is called once per frame
    void Update() {
        var playerPos = player.transform.position;

        transform.LookAt(player.transform);

        if (transform.position.x > playerPos.x)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (transform.position.x < playerPos.x)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (transform.position.z > playerPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime);
        }
        if (transform.position.z < playerPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime);
        }

        gameObject.GetComponent<Weapon>().Shoot();

        if (hp <= 0)
        {
            var exp = Instantiate(explosion, transform.position, new Quaternion());
            player.GetComponent<PlayerController>().enemies.Remove(gameObject);
            player = null;
            Destroy(exp, 3);
            Destroy(gameObject);
        }
    }
}
