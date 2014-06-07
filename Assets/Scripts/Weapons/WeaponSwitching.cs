using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class WeaponSwitching : MonoBehaviour {

    private int nrWeapons;
    private float firerateLvl;
    public float fireRate;
    private float ammolvl;
    public float maxAmmo;

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
            UpdateFireRate(firerateLvl);
            UpdateAmmo(ammolvl);
        }
    }

    public void UpdateFireRate(float fireRateLvl) {
        firerateLvl = fireRateLvl;
        if (fireRateLvl == 0) {
            fireRate = 0.2f;
        } else if (fireRateLvl == 1) {
            fireRate = 0.15f;
        } else if (fireRateLvl == 2) {
            fireRate = 0.1f;
        } else {
            fireRate = 0.05f;
        }
    }

    public void UpdateAmmo(float ammoLvl) {
        ammolvl = ammoLvl;
        if (ammoLvl == 0) {
            maxAmmo = 5.0f;
        } else if (ammoLvl == 1) {
            maxAmmo = 8.0f;
        } else if (ammoLvl == 2) {
            maxAmmo = 12.0f;
        } else {
            maxAmmo = 15.0f;
        }
    }
}