using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomberMovementController : MonoBehaviour {

    public GameObject explosion;
    GameObject Player;
    public int hp = 12;

    public void RegisterPlayer(GameObject player) {
        Player = player;
    }

	// Update is called once per frame
	void Update () {
        if (hp < 0) {

        }
	}
}
