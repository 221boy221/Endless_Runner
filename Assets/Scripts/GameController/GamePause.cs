using UnityEngine;
using System.Collections;

public class GamePause:MonoBehaviour {

	[SerializeField] private GUIStyle buttonStyle;
	[SerializeField] private GUIStyle labelStyle;

    //private PlayerSkillpoints playerSkillpoints;
    //private WeaponRotation weaponRotation;
    //private PlayerHealth playerHealth;
    public bool hasSkillpoints;
    
    
    void Awake() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        //playerSkillpoints = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<PlayerSkillpoints>();
        //weaponRotation = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponRotation>();
        //playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }	
    }

    void OnGUI() {
        if (Time.timeScale!=0) {
            return;
        }
        
        
        // UPGRADES 
        if (hasSkillpoints) {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 100, 150, 25), "You have skillpoints!");    
            /*
            // Increases player's fire rate
            if (GUI.Button(new Rect(832, 420, 256, 50), new GUIContent("Fire Rate"), buttonStyle)) {
                if (hasSkillpoints) {
                    if (weaponRotation.fireRate >= 0.2f) {
                        weaponRotation.fireRate -= 0.1f;
                        playerSkillpoints.IncreaseValue(-1);
                    }
                } else {
                    GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
                }
            }

            // Gives the player health
            if (GUI.Button(new Rect(832, 470, 256, 50), new GUIContent("Extra Health"), buttonStyle)) {
                if (hasSkillpoints) {
                    playerHealth.TakeDamage(-50);
                    playerSkillpoints.IncreaseValue(-1);
                } else {
                    GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
                }
            }
            */
        }

        
        


        
        // MENU 
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3 ((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

		GUI.Box(new Rect(-1, -1, 1922, 1082), new GUIContent());
		GUI.Label(new Rect(832, 520, 256, 50), new GUIContent("Game Paused"), labelStyle);

		if (GUI.Button(new Rect(832, 590, 256, 50), new GUIContent("Resume"), buttonStyle)) {
			TogglePause();
		} else if (GUI.Button(new Rect(832, 640, 256, 50), new GUIContent("Main Menu"), buttonStyle)) {
			Application.LoadLevel("MainMenu");
		}
    }

    public void TogglePause() {

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects) { // This will send a message to all GameObjects to run "GamePause"
            go.SendMessage("GamePause", SendMessageOptions.DontRequireReceiver);
        }
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0; // If it's 0 make it 1, else if 1 make it 0
    }

}
