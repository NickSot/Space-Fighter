using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomberMovementController : MonoBehaviour {

    public GameObject explosion;
    GameObject Player;
    public float hp = 12;

    public void RegisterPlayer(GameObject player) {
        Player = player;
    }

    public void Unregister() {
        Player = null;
    }

	// Update is called once per frame
	void Update () {
        var playerPos = Player.transform.position;

        transform.LookAt(Player.transform);

        if (transform.position.x > playerPos.x)
        {
            transform.position = new Vector3(transform.position.x - 3*Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (transform.position.x < playerPos.x)
        {
            transform.position = new Vector3(transform.position.x + 3*Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (transform.position.z > playerPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3*Time.deltaTime);
        }
        if (transform.position.z < playerPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3*Time.deltaTime);
        }

        if (hp < 0) {
            var exp = Instantiate(explosion, transform.position, new Quaternion());
            Player.GetComponent<PlayerController>().enemies.Remove(gameObject);
            Player = null;
            Destroy(exp, 3);
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<PlayerController>().hp -= 30;
            hp -= 100;
        }
    }
}
