using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class HowToPlay:MonoBehaviour {

    [SerializeField] private Texture2D howToPlayBG;
	[SerializeField] private GUIStyle labelHeadStyle;
	[SerializeField] private GUIStyle labelStyle;
	[SerializeField] private GUIStyle buttonStyle;

	private MainMenu mainMenu;
	private bool opened;

	void Start() {
		mainMenu = GetComponent<MainMenu>();
	}

	void OnGUI() {
        if (!opened) {
            return;
        }
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), howToPlayBG);
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

        // Back button
        if (GUI.Button(new Rect(25, 900, 150, 150), new GUIContent(), buttonStyle)) {
            mainMenu.Open();
        }
    }

	public void Open() {
		opened = true;
		mainMenu.Close();
	}

	public void Close() {
		opened = false;
	}

}