using UnityEngine;
using System.Collections;

public class MainMenu:MonoBehaviour {

	[SerializeField] private Texture logo;
	[SerializeField] private GUIStyle playStyle;
	[SerializeField] private GUIStyle instructionsStyle;
	[SerializeField] private GUIStyle quitStyle;

	private HowToPlay howToPlay;
	private bool opened = true;

	void Start() {
		howToPlay = GetComponent<HowToPlay>();
	}

    void OnGUI() {
        if (!opened) {
			return; 
        }

		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
		GUI.DrawTexture(new Rect(960 - logo.width / 2 * 0.65f, 25, logo.width * 0.65f, logo.height * 0.65f), logo);

		if(GUI.Button(new Rect(610, 520, 150, 150), new GUIContent(), playStyle)) {		
            Application.LoadLevel("testScene"); // Run game
		} else if(GUI.Button(new Rect(610, 590, 700, 60), new GUIContent(), instructionsStyle)) {
			howToPlay.Open();   // Opens the HowToPlay script
		} else if(GUI.Button(new Rect(610, 660, 700, 60), new GUIContent(), quitStyle)) {
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