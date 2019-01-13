using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    public GameObject canvas;
    public uint size = 270;
    public string sceneToLoad = "Level1";
    Transform text = null;
	// Use this for initialization
	void Start () {
        text = canvas.transform.GetChild(0).GetChild(1);
	}

    // Update is called once per frame
    void Update() {
        if (text.position.y >= size || Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }

        var newPosition = new Vector3(text.position.x, text.position.y + 20*Time.deltaTime);

        text.position = newPosition;
	}
}
