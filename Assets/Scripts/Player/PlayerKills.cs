using UnityEngine;
using System.Collections;
// Gemaakt door Boy

public class PlayerKills : MonoBehaviour {

    private float kills = 0.0f;
    private GUIText killText;

    void Awake() {
        killText = GameObject.FindGameObjectWithTag("PlayerKillsUI").GetComponent<GUIText>();
        killText.text = "Kills: " + kills;
    }

    public void IncreaseValue(int incr) {
        kills += incr;
        killText.text = "Kills: " + kills;
    }
}
