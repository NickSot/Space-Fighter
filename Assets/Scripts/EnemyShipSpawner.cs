﻿using System.Collections;
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
    PlayableGridCell[,] PlayableAreaGrid = null;
    bool spawningFinished = false;
    public uint shipsCount = 5;

    public static EnemyShipSpawner Instance { get; set; }

    public void RegisterPlayer(GameObject obj) {
        PlayerShip = obj;
    }

    public void UnregisterPlayer() {
        PlayerShip = null;
    }

    void DeterminePlayableGrid() {

    }

    void SpawnShips() {
        for (int i = 0; i < shipsCount; i++) {
            var positionToSpawn = new Vector3(Random.Range(0, 1), 5, Random.Range(0, 1));

            Instantiate(EnemyShip, positionToSpawn, new Quaternion());
        }
    }

	// Update is called once per frame
	void Update () {
        if (!spawningFinished) {
            SpawnShips();

            spawningFinished = true;
        }
	}
}
