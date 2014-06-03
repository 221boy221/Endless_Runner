using UnityEngine;
using System.Collections;

public class PlayerXP : MonoBehaviour 
{

    private float xp = 0.0f;
    private float lvlUpXP = 500.0f;
    private PlayerLvl playerLvl;
    private GUIText xpText;


    void Awake() {
        playerLvl = GameObject.FindGameObjectWithTag("PlayerLvlUI").GetComponent<PlayerLvl>();
        xpText = GameObject.FindGameObjectWithTag("PlayerXPUI").GetComponent<GUIText>();
        xpText.text = "XP: " + xp + " / " + lvlUpXP;
    }

    public void IncreaseValue(int incr) {
        xp += incr;
        xpText.text = "XP: " + xp + " / " + lvlUpXP;

        if (xp >= lvlUpXP) {   
            xp -= lvlUpXP;
            playerLvl.IncreaseValue(1);
            lvlUpXP += lvlUpXP;
            Awake();
        }
    }
}
