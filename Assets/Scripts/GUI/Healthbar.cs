using UnityEngine;

public class Healthbar : MonoBehaviour {

	[SerializeField] private Texture2D hpBar;
	[SerializeField] private Texture2D hbBackground;
	[SerializeField] private Texture2D hpOverlay;

    private PlayerHealth playerHealth;
    private EnemyBehaviour enemyHealth;
    private float maxHealth = 0.0f;
	private Vector2 position;
    
    protected bool paused = false;

	

	void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyBehaviour>();
        if (gameObject.tag == "Player") {
            maxHealth = playerHealth.GetHealth;
        } else if (enemyHealth != null) {
            maxHealth = enemyHealth.Health;
        }
	}

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (!paused) ? true : false;  // This is basically: if (paused = true) paused = false; else paused = true;
    }

	void Update() {
		position = Camera.main.WorldToScreenPoint(transform.position);
	}

	void OnGUI() {
        if (!paused) {
            GUI.DrawTexture(new Rect(position.x - 45, (Screen.height - position.y) + (position.y / 2), hbBackground.width / 7, hbBackground.height / 5), hbBackground);
            if (gameObject.tag == "Player") {
                GUI.DrawTexture(new Rect(position.x - 40, ((Screen.height - position.y) + (position.y / 2) + 1), (hpBar.width / 7) / (maxHealth / playerHealth.GetHealth), hpBar.height / 5), hpBar);
            } else {
                GUI.DrawTexture(new Rect(position.x - 40, ((Screen.height - position.y) + (position.y / 2) + 1), (hpBar.width / 7) / (maxHealth / enemyHealth.Health), hpBar.height / 5), hpBar);
            }

            GUI.DrawTexture(new Rect(position.x - 45, ((Screen.height - position.y) + (position.y / 2)), hpOverlay.width / 7, hpOverlay.height / 5), hpOverlay);
        }       
	}
}
