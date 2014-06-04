using UnityEngine;
using System.Collections;

public class GamePause:MonoBehaviour {
    
    [SerializeField] private Texture2D pauseBG;
	[SerializeField] private GUIStyle labelStyle;
    [SerializeField] private GUIStyle upgradeStyle;
    [SerializeField] private GUIStyle resumeStyle;
    [SerializeField] private GUIStyle mainmenuStyle;

    private PlayerSkillpoints playerSkillpoints;
    private WeaponRotation weaponRotation;
    private PlayerHealth playerHealth;
    public bool hasSkillpoints;
    
    
    void Awake() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        playerSkillpoints = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<PlayerSkillpoints>();
        weaponRotation = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponRotation>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
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
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseBG);
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3 ((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
		GUI.Box(new Rect(-1, -1, 1922, 1082), new GUIContent());
        
        // UPGRADES 
        if (hasSkillpoints) {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 100, 150, 25), "You have skillpoints!"); 
        }
        // Fire rate
        GUI.Label(new Rect(350, 275, 256, 50), new GUIContent("Fire Rate: "), labelStyle);
        if (GUI.Button(new Rect(500, 250, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                /*
                if (weaponRotation.fireRate >= 0.2f) {
                    weaponRotation.fireRate -= 0.1f;
                    playerSkillpoints.IncreaseValue(-1);
                }
                */
                Debug.Log("Skillpoint spent");
                } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
                Debug.Log("No Skillpoints");
            }
        }
        // Health
        GUI.Label(new Rect(350, 375, 256, 50), new GUIContent("Health: "), labelStyle);
        if (GUI.Button(new Rect(500, 350, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                //playerHealth.TakeDamage(-50);
                //playerSkillpoints.IncreaseValue(-1);
                Debug.Log("Skillpoint spent");
            } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
                Debug.Log("No Skillpoints");
            }
        }

        
        


        
        // MENU 
		GUI.Label(new Rect(832, 520, 256, 50), new GUIContent("Game Paused"), labelStyle);

		if (GUI.Button(new Rect(832, 600, 150, 150), new GUIContent(), resumeStyle)) {
			TogglePause();
		} else if (GUI.Button(new Rect(832, 800, 150, 150), new GUIContent(), mainmenuStyle)) {
			Application.LoadLevel("MainMenu");
		}
    }

    public void TogglePause() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        // This will send a message to all GameObjects to run "GamePause"
        foreach (GameObject go in objects) { 
            go.SendMessage("GamePause", SendMessageOptions.DontRequireReceiver);
        }
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0; // If it's 0 make it 1, else if 1 make it 0
    }
}