using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class PlayerSkillpoints : MonoBehaviour {

    public float Skillpoints = 0.0f;
    private GamePause gamePause;
    public GUIText SkillpointsText;

    void Awake() {
        gamePause = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<GamePause>();
        SkillpointsText = GameObject.FindGameObjectWithTag("PlayerSkillpointsUI").GetComponent<GUIText>();
        SkillpointsText.text = "Skillpoints: " + Skillpoints;
    }

    public void IncreaseValue(int incr) {
        Skillpoints += incr;
        SkillpointsText.text = "Skillpoints: " + Skillpoints;

        // This makes it so he can only get the button to open the menu once he has skillpoints to spend.
        if (Skillpoints > 0) {
            gamePause.hasSkillpoints = true;
            //GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height - 100, 150, 25), "Skillpoints available!");
        } else {
            gamePause.hasSkillpoints = false;
        }
    }
}
