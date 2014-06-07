using UnityEngine;
using System.Collections;
// Gemaakt door Boy

public class GamePause:MonoBehaviour {
    
    [SerializeField] private Texture2D pauseBG;
	[SerializeField] private GUIStyle labelStyle;
    [SerializeField] private GUIStyle upgradeStyle;
    [SerializeField] private GUIStyle resumeStyle;
    [SerializeField] private GUIStyle mainmenuStyle;

    private float firerateLvl = 0;
    private float ammoLvl = 0;
    public float damageLvl = 0;
    
    private PlayerSkillpoints playerSkillpoints;
    private WeaponSwitching weaponSwitching;
    private PlayerHealth playerHealth;
    public bool hasSkillpoints;
    
    
    void Awake() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        playerSkillpoints = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<PlayerSkillpoints>();
        weaponSwitching = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponSwitching>();
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
        // Show skillpoints
        GUI.Label(new Rect(500, 150, 256, 50), new GUIContent("You have " + playerSkillpoints.Skillpoints + " skillpoint(s) left."), labelStyle); 
        // Fire rate
        GUI.Label(new Rect(300, 275, 256, 50), new GUIContent("Fire Rate - Lvl " + firerateLvl), labelStyle);
        if (GUI.Button(new Rect(500, 250, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                if (firerateLvl < 3) {
                    firerateLvl += 1;
                    playerSkillpoints.IncreaseValue(-1);
                    weaponSwitching.UpdateFireRate(firerateLvl);
                }
            } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
            }
        }
        // Health
        GUI.Label(new Rect(355, 375, 256, 50), new GUIContent("Health +50 "), labelStyle);
        if (GUI.Button(new Rect(500, 350, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                if (playerHealth.GetHealth < 100) {
                    playerHealth.IncreaseHealth(50);
                    playerSkillpoints.IncreaseValue(-1);
                }
            } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
            }
        }
        // Damage
        GUI.Label(new Rect(810, 275, 256, 50), new GUIContent("Damage - Lvl " + damageLvl), labelStyle);
        if (GUI.Button(new Rect(1000, 250, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                if (damageLvl < 3) {
                    damageLvl += 1;
                    playerSkillpoints.IncreaseValue(-1);
                }
            } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
            }
        }
        // Ammo
        GUI.Label(new Rect(830, 375, 256, 50), new GUIContent("Ammo - Lvl " + ammoLvl), labelStyle);
        if (GUI.Button(new Rect(1000, 350, 75, 75), new GUIContent(), upgradeStyle)) {
            if (hasSkillpoints) {
                if (ammoLvl < 3) {
                    ammoLvl += 1;
                    weaponSwitching.UpdateAmmo(ammoLvl);
                    playerSkillpoints.IncreaseValue(-1);
                }
            } else {
                GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "NO SKILLPOINTS");
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