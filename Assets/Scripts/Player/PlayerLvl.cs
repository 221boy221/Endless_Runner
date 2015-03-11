using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class PlayerLvl : MonoBehaviour {

    private float lvl = 1.0f;
    private PlayerSkillpoints playerSkillpoints;
    private GUIText lvlText;

    void Awake() {
        playerSkillpoints = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<PlayerSkillpoints>();
        lvlText = GameObject.FindGameObjectWithTag("PlayerLvlUI").GetComponent<GUIText>();
        lvlText.text = "Lvl: " + lvl;
    }

    public void IncreaseValue(int incr) {
		GetComponent<AudioSource>().Play ();
        lvl += incr;
        lvlText.text = "Lvl: " + lvl;
        // On every lvl up, give the player * skillpoints.
        playerSkillpoints.IncreaseValue(1);
    }

}
