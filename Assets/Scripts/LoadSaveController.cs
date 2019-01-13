using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;

public class LoadSaveController : MonoBehaviour {
    [Serializable]
    public class SaveData {
        public string currentScene;
        public string date;
    }
       
    public static void Load(string date) {
        StreamReader sr = new StreamReader(File.OpenRead("player_data.json"));

        SaveData obj;

        do {
            string value = sr.ReadLine();

            obj = JsonUtility.FromJson<SaveData>(value);

        } while (date != obj.date);

        SceneManager.LoadScene(obj.currentScene);
    }

    public static void Save(string scene) {
        FileStream fs = new FileStream("player_data.json", FileMode.Append);

        SaveData valueString = new SaveData();

        valueString.currentScene = scene;
        valueString.date = DateTime.Now.ToString();

        string valueToWrite = JsonUtility.ToJson(valueString, true);

        fs.Write(Encoding.ASCII.GetBytes(valueToWrite), 0, valueToWrite.Length);

        fs.Close();
    }
	
}
