using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	public GameObject nextTransform;

	public GameObject weakness; // <-- tag van kogel waar hij niet tegen kan.
	public GameObject strength; // <-- tag van kogel waar hij sterker van wordt.

	void Update() {
		Movement();

		if (this.transform.position.x < -6.7) {
			Destroy(this.gameObject);
		}
	}

	virtual protected void Movement() {
		transform.Translate (new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == weakness.gameObject.tag) {
			Debug.Log ("Hit by weakness");
			GetDamage (100);
		} else if (other.gameObject.tag == strength.gameObject.tag) {
			Debug.Log("Hit by strength - My power is rising!");
			GetStronger();
		}
	}

	void GetStronger() {
		//TransformEnemy("health");
		TransformEnemy();
	}

	void TransformEnemy() {
		if (nextTransform != null) {
			Instantiate (nextTransform, new Vector2(this.transform.position.x,this.transform.position.y +0.17f), this.transform.rotation);
			Destroy (this.gameObject);
		}
	}

	void GetDamage (float dmg) {
        scriptEnemy.health -= dmg;
        if (scriptEnemy.health <= 0) {
			Death();
		}
	}

	void Death() {
		Destroy (this.gameObject);
	}
}

// Ga quads gebruiken als placeholder en 2d rigitbodies