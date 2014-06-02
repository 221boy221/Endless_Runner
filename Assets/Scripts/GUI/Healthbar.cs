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
        //GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
        GUI.DrawTexture(new Rect(position.x - 45, (Screen.height - position.y) + (position.y / 2), hbBackground.width / 7, hbBackground.height / 5), hbBackground);
        if (gameObject.tag == "Player") {
            GUI.DrawTexture(new Rect(position.x - 40, ((Screen.height - position.y) + (position.y / 2) + 1), (hpBar.width / 7) / (maxHealth / playerHealth.Health), hpBar.height / 5), hpBar);
        } else {
            GUI.DrawTexture(new Rect(position.x - 40, ((Screen.height - position.y) + (position.y / 2) + 1), (hpBar.width / 7) / (maxHealth / enemyHealth.Health), hpBar.height / 5), hpBar);
        }

        GUI.DrawTexture(new Rect(position.x - 45, ((Screen.height - position.y) + (position.y / 2)), hpOverlay.width / 7, hpOverlay.height / 5), hpOverlay);
	}
}
