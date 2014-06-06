using UnityEngine;
using System.Collections;

public class PlayerXP : MonoBehaviour {

    [SerializeField] private GUIStyle labelStyle;
    private float xp = 0.0f;
    private float lvlUpXP = 1000.0f;
    private PlayerLvl playerLvl;

    void Awake() {
        playerLvl = GameObject.FindGameObjectWithTag("PlayerLvlUI").GetComponent<PlayerLvl>();
    }

    public void IncreaseValue(int incr) {
        xp += incr;

        if (xp >= lvlUpXP) {   
            xp -= lvlUpXP;
            playerLvl.IncreaseValue(1);
			lvlUpXP += Mathf.Floor((500 + (lvlUpXP / 4)));
            Awake();
        }
    }

    void OnGUI() {
        if (Time.timeScale!=1) {
            return;
        }
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
            GUI.Label(new Rect(860, 985, 256, 50), new GUIContent("XP: " + xp + " / " + lvlUpXP), labelStyle);
    }

	public float Xp {
		get { return xp; }
	}
	public float XpToLevelUp {
		get { return lvlUpXP; }
	}
}
