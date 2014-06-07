using UnityEngine;
using System.Collections;
// Gemaakt door Ramses
public class XpbarScript : MonoBehaviour {

	[SerializeField] private Texture2D xpBar;
	[SerializeField] private Texture2D xpBackground;
	[SerializeField] private Texture2D xpOverlay;
	
	private PlayerXP playerXp;
	
	protected bool paused = false;
	
	
	
	void Start() {
		playerXp = GameObject.FindGameObjectWithTag("PlayerXPUI").GetComponent<PlayerXP>();
	}
	
	void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
		paused = (!paused) ? true : false;  // This is basically: if (paused = true) paused = false; else paused = true;
	}
	
	void OnGUI() {
		if (!paused) {
			GUI.DrawTexture(new Rect(20, (Screen.height - 30), (Screen.width-40), xpBackground.height / 5), xpBackground);
			GUI.DrawTexture(new Rect(20, (Screen.height - 30), (Screen.width-40) / (playerXp.XpToLevelUp / playerXp.Xp), xpBar.height / 5), xpBar);
			//GUI.DrawTexture(new Rect(0, (Screen.height - 30), Screen.width + 20, xpOverlay.height /2), xpOverlay);
		}       
	}
}
