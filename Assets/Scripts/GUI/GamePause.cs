using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class GamePause : MonoBehaviour {

    public GameObject pauseScreen;
    public PlayerData playerData;
    /*
    public Text textFR;
    public Text textDmg;
    public Text textAmmo;
    */
    void Awake() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseAll();
            ToggleMenu();
        }
    }

    void PauseAll() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        // This will send a message to all GameObjects to run "GamePause"
        foreach (GameObject go in objects) { 
            go.SendMessage("GamePause", SendMessageOptions.DontRequireReceiver);
        }

        // Toggle Time.timeScale
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0; 
    }

    void ToggleMenu() {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        /*
        if (pauseScreen.activeSelf == true) {
            textFR.text = "Fire Rate - Lvl " + playerData.fireRateLvl;
            textDmg.text = "Damage - Lvl " + playerData.damageLvl;
            textAmmo.text = "Ammo - Lvl " + playerData.ammoLvl;
        }
        */
    }

    // For the UI
    public void Resume() {
        PauseAll();
        ToggleMenu();
    }
}