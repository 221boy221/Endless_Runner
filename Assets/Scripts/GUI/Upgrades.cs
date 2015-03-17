using UnityEngine;
using System.Collections;

    // Boy Voesten

public class Upgrades : MonoBehaviour {

    private PlayerData playerData;

    void Start() {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

    public void UpgradeFR() {
        if (playerData.skillpoints <= 0) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseFR(1);
    }

    public void UpgradeDMG() {
        if (playerData.skillpoints <= 0) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseDMG(1);
    }

    public void UpgradeHP() {
        if (playerData.skillpoints <= 0) return;
        playerData.IncreaseSP(-1);

        // todo
    }

    public void UpgradeAMMO() {
        if (playerData.skillpoints <= 0) return;
        playerData.IncreaseSP(-1);

        playerData.IncreaseAmmo(1);
    }

}
