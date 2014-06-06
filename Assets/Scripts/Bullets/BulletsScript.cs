using UnityEngine;
using System.Collections;

// Gemaakt door Ramses en Boy

public class BulletsScript : MonoBehaviour {

	public float destroyTime;
	public float speed;
	public static float damage = 50.0f;
//	public static float GetDamage { get { return damage; } }
    private float damageLvl;
    private GamePause gamePause;

	void Start() {
		Destroy (gameObject, destroyTime); // gameObject inplaats van this want met this verwijder je het script.  Bij de destroy functie geef je wat hij weg moet halen en wanneer.
        gamePause = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<GamePause>();
        UpdateDamage();
	}
	
	void Update() {
		this.transform.Translate (Vector2.right * speed * Time.deltaTime); // ik heb ons booger script hiervoor gebruikt. Maar inplaats van Vector3.forward heb ik Vector2.right gebruikt wat hetzelfde effect heeft maar dan in 2D
	}

	// Removes the bullet on touch
    private void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag != "Player") {
			Destroy (this.gameObject);
		}
	}

    public void UpdateDamage() {
        damageLvl = gamePause.damageLvl;
        if (damageLvl == 1) {
            damage = 70.0f;
            Debug.Log("Current damage: " + damage);
        } else if (damageLvl == 2) {
            damage = 90.0f;
            Debug.Log("Current damage: " + damage);
        } else if (damageLvl == 3) {
            damage = 110.0f;
            Debug.Log("Current damage: " + damage);
        }
    }
	
}
