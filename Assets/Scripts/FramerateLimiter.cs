using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {
	public int targetFrameRate = 60;
    public GameObject player;
	float dt = 0f;
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.targetFrameRate != targetFrameRate){
			Application.targetFrameRate = targetFrameRate;
		}
		dt += (Time.unscaledDeltaTime - dt);
	}

	void OnGUI() {
        try
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);

            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 25;
            style.normal.textColor = new Color(1, 1, 1, 1f);

            string hpText = string.Format("{0} hp", player.GetComponent<PlayerController>().hp);

            GUI.Label(rect, hpText, style);
        }
        catch (Exception ex) {

        }
    }
}
