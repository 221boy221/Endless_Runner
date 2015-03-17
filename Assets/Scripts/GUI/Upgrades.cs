using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class Upgrades : MonoBehaviour {

    private PlayerData playerData;
    private PlayerHealth playerHealth;
    public Text textFR;
    public Text textDmg;
    public Text textAmmo;

    void Start() {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
    }
            
    public void UpgradeFR() {
        if (playerData.skillpoints <= 0 || playerData.fireRateLvl >= 3) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseFR(1);
        textFR.text = "Fire Rate - Lvl " + playerData.fireRateLvl;
    }

    public void UpgradeDMG() {
        if (playerData.skillpoints <= 0 || playerData.damageLvl >= 3) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseDMG(1);
        textDmg.text = "Damage - Lvl " + playerData.damageLvl;
    }

    public void UpgradeHP() {
        if (playerData.skillpoints <= 0) return;
        playerData.IncreaseSP(-1);

        // todo
        playerHealth.IncreaseHealth(50);
    }

    public void UpgradeAMMO() {
        if (playerData.skillpoints <= 0 || playerData.ammoLvl >= 3) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseAmmo(1);
        textAmmo.text = "Ammo - Lvl " + playerData.ammoLvl;
    }

}
