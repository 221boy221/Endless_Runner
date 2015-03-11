using UnityEngine;
using System.Collections;

// Gemaakt door Ramses

public class portalScript : MonoBehaviour {

	BackgroundSwithcing backgroundswitch;

	GameObject[] allEnemies;

	void Awake() {
		backgroundswitch = GameObject.FindGameObjectWithTag("GameController").GetComponent<BackgroundSwithcing>();
	}

	void Update() {
		transform.Translate (new Vector2(-0.9f,0)*Time.deltaTime,Space.World);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			backgroundswitch.changeLevel();
			allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
			for (int i = 0;i < allEnemies.Length; i++) {
				Destroy(allEnemies[i]);
			}
			GetComponent<AudioSource>().Play();
			if(!GetComponent<AudioSource>().isPlaying){
				Destroy(this.gameObject);
			}
		}
	}

}
