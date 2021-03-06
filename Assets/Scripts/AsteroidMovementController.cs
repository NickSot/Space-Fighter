﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementController : MonoBehaviour {
    public GameObject explosion;
    public float AsteroidSpeed = 2;
    public float AsteroidAngularSpeed = 2;
    public float hp;

    GameObject player = null;

    public void RegisterPlayer(GameObject obj) {
        player = obj;
    }

    public void UnregisterPlayer() {
        player = null;
    }

    // Use this for initialization
    void Start () {
        Vector2 direction2d = Random.insideUnitCircle;
        direction2d.Normalize();
        Vector3 direction3d = new Vector3(direction2d.x, 0, direction2d.y);
        var rb = GetComponent<Rigidbody>();
        rb.velocity = direction3d * AsteroidSpeed;
        rb.angularVelocity = Random.onUnitSphere * AsteroidAngularSpeed;
        hp = 100f;
	}

    void Update() {
        if (hp <= 0) {
            var exp = Instantiate(explosion, transform.position, new Quaternion());
            player.GetComponent<PlayerController>().enemies.Remove(gameObject);
            UnregisterPlayer();
            Destroy(exp, 3);
            Destroy(gameObject);
        }
    }
}
