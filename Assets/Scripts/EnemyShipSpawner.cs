using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyShipSpawner : MonoBehaviour {
    public GameObject EnemyShip;
    public GameObject EnemyBomber;
    GameObject PlayerShip;
    bool spawningFinished = false;
    public uint shipsCount = 5;
    int killedCount = 0;

    public static EnemyShipSpawner Instance { get; set; }

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPlayer(GameObject obj) {
        PlayerShip = obj;
    }

    public void UnregisterPlayer() {
        PlayerShip = null;
    }

    void SpawnShips(GameObject obj) {
        for (int i = 0; i < shipsCount; i++) {
            var positionToSpawn = new Vector3(0, 0, 0);

            while (positionToSpawn.x < PlayerShip.transform.position.x + 1 && positionToSpawn.x > PlayerShip.transform.position.x - 1)
            {
                positionToSpawn.x = Random.Range(0, 1);

                positionToSpawn = Camera.main.ViewportToWorldPoint(positionToSpawn);
            }

            positionToSpawn.y = 5;

            var es = Instantiate(obj, positionToSpawn, new Quaternion());

            if (obj.CompareTag("EnemyShip"))
                es.GetComponent<EnemyShipMovementController>().RegisterPlayer(PlayerShip);
            else
                es.GetComponent<EnemyBomberMovementController>().RegisterPlayer(PlayerShip);

            PlayerShip.GetComponent<PlayerController>().enemies.Add(es);
        }
    }

	// Update is called once per frame
	void Update () {
        if (!spawningFinished && PlayerShip != null) {
            if (killedCount == 0)
            {
                SpawnShips(EnemyShip);
            }
            else {
                SpawnShips(EnemyBomber);
            }

            spawningFinished = true;
        }

        if (killedCount == 2) {
            PlayerShip.GetComponent<PlayerController>().victory = true;
        }

        if (PlayerShip.GetComponent<PlayerController>().enemies.Count == 0) {
            killedCount++;

            spawningFinished = false;
        }
	}
}
