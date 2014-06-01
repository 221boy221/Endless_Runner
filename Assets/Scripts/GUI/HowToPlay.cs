using UnityEngine;
using System.Collections;

public class HowToPlay:MonoBehaviour {

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

		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

		labelHeadStyle.alignment = TextAnchor.MiddleLeft;
		labelStyle.alignment = TextAnchor.MiddleLeft;

		GUI.Label(new Rect(270, 360, 100, 50), new GUIContent("Player controls:"), labelHeadStyle);
		GUI.Label(new Rect(270, 410, 100, 50), new GUIContent("Mouse: Aim"), labelStyle);
		GUI.Label(new Rect(270, 460, 100, 50), new GUIContent("Mouse1 click: Shoot"), labelStyle);
		GUI.Label(new Rect(270, 510, 100, 50), new GUIContent("1 - 9: Select weapon"), labelStyle);
        GUI.Label(new Rect(270, 560, 100, 50), new GUIContent("Space: Jump"), labelStyle);

		labelHeadStyle.alignment = TextAnchor.MiddleRight;
		labelStyle.alignment = TextAnchor.MiddleRight;

		if(GUI.Button(new Rect(860, 1000, 200, 50), new GUIContent("Back"), buttonStyle))
			mainMenu.Open();
	}

	public void Open() {
		opened = true;
		mainMenu.Close();
	}

	public void Close() {
		opened = false;
	}

}