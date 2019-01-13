using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour {

    string messageToPrint;
    bool showMessage = false;

    public void PrintMessage(string message) {
        messageToPrint = message;
        showMessage = true;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnGUI()
    {
        if (showMessage)
        {
            try
            {
                int w = Screen.width, h = Screen.height;

                GUIStyle style = new GUIStyle();

                Rect rect = new Rect(0, 0, w, h * 2 / 100);

                style.alignment = TextAnchor.UpperCenter;
                style.fontSize = h * 2 / 40;
                style.normal.textColor = new Color(1, 1, 1, 1f);

                //string hpText = "Nice! Now we've got a... Ah, shit!, there's more incoming!";

                GUI.Label(rect, messageToPrint, style);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
