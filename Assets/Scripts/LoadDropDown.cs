using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class LoadDropDown : MonoBehaviour {
    [Serializable]
    public class SaveData
    {
        public string currentScene;
        public string date;
    }

    [Serializable]
    public class SaveDataCollection
    {
        public List<SaveData> data;
    }

    // Use this for initialization
    void Start () {
        StreamReader sr = new StreamReader("player_data.json");

        string data;

        data = sr.ReadToEnd();

        SaveDataCollection s = JsonUtility.FromJson<SaveDataCollection>(data);

        Debug.Log(s.data.Count);

        sr.Close();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
