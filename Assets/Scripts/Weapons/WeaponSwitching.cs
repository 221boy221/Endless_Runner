using UnityEngine;
using System.Collections;

    // Boy Voesten

public class WeaponSwitching : MonoBehaviour {

    protected bool paused = false;
    public GameObject[] weapons;
    private WeaponShoot weaponShoot;
    private int currentWeapon = 0;
    private int nrWeapons;

    void Start() {
        nrWeapons = weapons.Length;
        SwitchWeapon(currentWeapon); // Give player the default gun to start with
    }

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (paused == false) ? true : false;  // Toggle bool paused
    }

    void Update() {
        if (paused) return;
            
        for (int i = 0; i <= nrWeapons; i++) {
            // Keyboard number pressed
            if (Input.GetKeyDown("" + i)) {
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);
            }
        }
    }

    // Set the selected weapon to active(true) and others to active(false)
    void SwitchWeapon(int weapon) { 
        for (int i = 0; i < nrWeapons; i++) {
            if (i == weapon) {
                weapons[i].gameObject.SetActive(true);
                weaponShoot = weapons[i].gameObject.GetComponentInChildren<WeaponShoot>();
            } else {
                weapons[i].gameObject.SetActive(false);
            }
            weaponShoot.UpdateUI();
            weaponShoot.ApplyUpgrades();
        }
    }

}