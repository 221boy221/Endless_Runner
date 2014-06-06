using UnityEngine;
using System.Collections;
// Gemaakt door Boy

public class GameOver : MonoBehaviour {

    [SerializeField] private Texture2D gameoverBG;
    [SerializeField] private GUIStyle retryStyle;
    [SerializeField] private GUIStyle mainmenuStyle;

    void OnGUI() {

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameoverBG);

        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

        if (GUI.Button(new Rect(450, 850, 150, 150), new GUIContent(), retryStyle)) {
            Application.LoadLevel("testScene");
        } else if (GUI.Button(new Rect(250, 850, 150, 150), new GUIContent(), mainmenuStyle)) {
            Application.LoadLevel("MainMenu");
        }
    }
}