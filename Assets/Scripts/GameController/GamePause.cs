using UnityEngine;
using System.Collections;

public class GamePause:MonoBehaviour {

	[SerializeField] private GUIStyle buttonStyle;
	[SerializeField] private GUIStyle labelStyle;

	private bool paused = false;

    void Awake() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }	
    }

    void OnGUI() {
        if (!paused) {
            return;
        }
			
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3 ((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

		GUI.Box(new Rect(-1, -1, 1922, 1082), new GUIContent());
		GUI.Label(new Rect(832, 520, 256, 50), new GUIContent("Game Paused"), labelStyle);

		if (GUI.Button(new Rect(832, 590, 256, 50), new GUIContent("Resume"), buttonStyle)) {
			TogglePause();
		} else if (GUI.Button(new Rect(832, 640, 256, 50), new GUIContent("Main Menu"), buttonStyle)) {
			Application.LoadLevel("MainMenu");
		}
    }

    private void TogglePause() {
		Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
		paused = Time.timeScale == 0;
    }

}
