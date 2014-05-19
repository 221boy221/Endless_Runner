using UnityEngine;
using System.Collections;

public class BulletsScript : MonoBehaviour {

	public float destroyTime;
	public float speed;
	
	void Start() {
		Destroy (gameObject, destroyTime); // gameObject inplaats van this want met this verwijder je het script.  Bij de destroy functie geef je wat hij weg moet halen en wanneer.
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
}
