using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLoadClick() {

    }

    public void OnPlayClick() {
        SceneManager.LoadScene("Intro1");
    }

    public void OnExitClick() {
        Application.Quit();
    }
}
