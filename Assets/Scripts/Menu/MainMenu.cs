﻿using UnityEngine;
using System.Collections;

public class MainMenu:MonoBehaviour {
	[SerializeField] private Texture logo;

	[SerializeField] private GUIStyle buttonStyle;

	private HowToPlay howToPlay;

	private bool opened = true;

	void Start() {
		howToPlay = GetComponent<HowToPlay>();
	}

    void OnGUI() {
		if(!opened) // If opened = false
			return; 

		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
		GUI.DrawTexture(new Rect(960 - logo.width / 2 * 0.65f, 25, logo.width * 0.65f, logo.height * 0.65f), logo);

		if(GUI.Button(new Rect(610, 520, 700, 60), new GUIContent("Play"), buttonStyle)) {
			// Run game
            Application.LoadLevel("mockup_01");
            
		} else if(GUI.Button(new Rect(610, 590, 700, 60), new GUIContent("How to play"), buttonStyle)) {
			howToPlay.Open();   // Opens the HowToPlay script
		} else if(GUI.Button(new Rect(610, 660, 700, 60), new GUIContent("Quit"), buttonStyle)) {
			Application.Quit(); // Quits the game
		}
    }

	public void Open() {
		opened = true;

		howToPlay.Close();
	}

	public void Close() {
		opened = false;
	}
}