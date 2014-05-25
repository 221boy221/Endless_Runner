using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

    private int nrWeapons;
    public GameObject[] weapons; // Array holding all weapons
    public int currentWeapon = 0;
    protected bool paused = false;

    void Start() {
        nrWeapons = weapons.Length;
        SwitchWeapon(currentWeapon); // Give player the default gun to start with
    }

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (paused == false) ? true : false;  // This is basically: if (paused = true) paused = false; else paused = true;
    }

    void Update() {
        if (!paused) {
            for (int i = 0; i <= nrWeapons; i++) {
                if (Input.GetKeyDown("" + i)) {
                    currentWeapon = i - 1;
                    SwitchWeapon(currentWeapon);
                }
            }
        }
    }

    void SwitchWeapon(int index) { // Set the selected weapon to active(true) and others to active(false)
        for (int i = 0; i < nrWeapons; i++) {
            if (i == index) {
                weapons[i].gameObject.SetActive(true);
            } else {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}