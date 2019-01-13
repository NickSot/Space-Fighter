using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector2 direction2d = player.transform.position;

        direction2d.Normalize();

        Vector3 direction3d = new Vector3(direction2d.x, 0, direction2d.y);

        var rb = GetComponent<Rigidbody>();

        rb.velocity = direction3d * 0.6f;
        
        //rb.angularVelocity = Random.onUnitSphere * AsteroidAngularSpeed;

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
