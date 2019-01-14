using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyShipSpawner : MonoBehaviour {
    public GameObject EnemyShip;
    GameObject PlayerShip;
    bool spawningFinished = false;
    public uint shipsCount = 5;

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

    void SpawnShips() {
        for (int i = 0; i < shipsCount; i++) {
            var positionToSpawn = new Vector3();

            while (positionToSpawn.x < PlayerShip.transform.position.x + 1 && positionToSpawn.x > PlayerShip.transform.position.x - 1)
            {
                positionToSpawn.x = Random.Range(0, 1);

                positionToSpawn = Camera.main.ViewportToWorldPoint(positionToSpawn);
            }

            positionToSpawn.y = 5;

            var es = Instantiate(EnemyShip, positionToSpawn, new Quaternion());

            es.GetComponent<EnemyShipMovementController>().RegisterPlayer(PlayerShip);
        }
    }

	// Update is called once per frame
	void Update () {
        if (!spawningFinished && PlayerShip != null) {
            /*StreamWriter sw = new StreamWriter("file.txt");

            sw.WriteLine("Entered the IF!");

            sw.Close();
            */

            SpawnShips();

            spawningFinished = true;
        }
	}
}
