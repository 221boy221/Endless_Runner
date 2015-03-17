using UnityEngine;
using System.Collections;

// Gemaakt door Ramses en Boy

public class BulletsScript : MonoBehaviour {

	public float destroyTime;
	public float speed;
	public float damage = 50.0f;
    private float damageLvl;
    private PlayerData playerData;

	void Start() {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        UpdateDamage();
        // Start Destroy timer
        Destroy(gameObject, destroyTime);
	}
	
	void Update() {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}

	// Removes the bullet on touch
    private void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag != "Player") {
			Destroy (gameObject);
		}
	}

    public void UpdateDamage() {
        switch (playerData.damageLvl) {
            case 0:
                damage = 50.0f;
                break;
            case 1:
                damage = 70.0f;
                break;
            case 2:
                damage = 90.0f;
                break;
            case 3:
                damage = 110.0f;
                break;
            default:
                damage = 110.0f;
                break;
        }
    }
	
}
