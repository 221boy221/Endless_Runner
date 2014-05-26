using UnityEngine;
using System.Collections;

public class PlayerLvl : MonoBehaviour 
{

    private float lvl = 0f;
    private PlayerSkillpoints playerSkillpoints;
    private GUIText lvlText;
    

    void Awake() {
        playerSkillpoints = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<PlayerSkillpoints>();
        lvlText = GameObject.FindGameObjectWithTag("PlayerLvlUI").GetComponent<GUIText>();
        lvlText.text = "Lvl: " + lvl;
    }

    public void IncreaseValue(int incr) {
        lvl += incr;
        lvlText.text = "Lvl: " + lvl;
        // On every lvl up, give the player ... skillpoints.
        playerSkillpoints.IncreaseValue(2);
    }
}
