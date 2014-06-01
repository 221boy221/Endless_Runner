using UnityEngine;

public class Healthbar : MonoBehaviour {

	[SerializeField] private Texture2D hpBar;
	[SerializeField] private Texture2D hbBackground;
	[SerializeField] private Texture2D hpOverlay;

	private PlayerHealth playerHealth;
    private EnemyBehaviour enemyHealth;
    private float maxHealth = 0.0f;

	private Vector2 position;

	void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyBehaviour>();
        if (gameObject.tag == "Player") {
            maxHealth = playerHealth.Health;
        } else if (enemyHealth != null) {
            maxHealth = enemyHealth.Health;
        }
	}

	void Update() {
		position = Camera.main.WorldToScreenPoint(transform.position);
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(position.x - 45, (Screen.height + -position.y) - 75, hbBackground.width / 7, hbBackground.height / 5), hbBackground);
        if (gameObject.tag == "Player") {
            GUI.DrawTexture(new Rect((position.x + 16) - 45, ((Screen.height + -position.y) + 3) - 75, (hpBar.width / 7) / (maxHealth / playerHealth.Health), hpBar.height / 5), hpBar);
        } else {
            GUI.DrawTexture(new Rect((position.x + 16) - 45, ((Screen.height + -position.y) + 3) - 75, (hpBar.width / 7) / (maxHealth / enemyHealth.Health), hpBar.height / 5), hpBar);
        }
        
		GUI.DrawTexture(new Rect(position.x - 45, (Screen.height + -position.y) - 75, hpOverlay.width / 7, hpOverlay.height / 5), hpOverlay);
	}
}
