using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public Texture gameoverBG;

    void OnGUI() {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameoverBG);
        if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2, 150, 25), "Try again")) {
            Application.LoadLevel("testScene");
        }
        if (GUI.Button(new Rect(Screen.width / 2 -75, Screen.height / 2 + 30, 150, 25), "Main Menu")) {
            Application.LoadLevel("MainMenu");
        }
    }
}