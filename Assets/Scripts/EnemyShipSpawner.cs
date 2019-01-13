using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour {
    protected class PlayableGridCell
    {
        public Bounds cellBounds;
        public bool isOccupied;
    };

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

            var positionToSpawn = Camera.main.WorldToViewportPoint(new Vector3(Random.Range(0, 1), 5));

            positionToSpawn = Camera.main.ViewportToWorldPoint(positionToSpawn);

            while (positionToSpawn != PlayerShip.transform.position) {

                positionToSpawn = Camera.main.WorldToViewportPoint(new Vector3(Random.Range(0, 1), 5));

                positionToSpawn = Camera.main.ViewportToWorldPoint(positionToSpawn);
            }

            positionToSpawn = Camera.main.ViewportToWorldPoint(positionToSpawn);

            var es = Instantiate(EnemyShip, positionToSpawn, new Quaternion());

            es.GetComponent<EnemyShipMovementController>().RegisterPlayer(PlayerShip);
        }
    }

	// Update is called once per frame
	void Update () {
        if (!spawningFinished && PlayerShip != null) {
            SpawnShips();

            spawningFinished = true;
        }
	}
}
