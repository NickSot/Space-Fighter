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
    PlayableGridCell[,] PlayableAreaGrid = null;

    public static EnemyShipSpawner Instance { get; set; }

    public void RegisterPlayer(GameObject obj) {
        PlayerShip = obj;
    }

    public void UnregisterPlayer() {
        PlayerShip = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
