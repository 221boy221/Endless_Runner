using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

    public GameObject[] weapons; // Array holding all weapons
    public int currentWeapon = 0;
    private int nrWeapons;

    void Start() {
        nrWeapons = weapons.Length;
        SwitchWeapon(currentWeapon); // Give player the default gun to start with
    }

    void Update() {
        for (int i = 0; i <= nrWeapons; i++) {
            if (Input.GetKeyDown("" + i)) {
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);
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