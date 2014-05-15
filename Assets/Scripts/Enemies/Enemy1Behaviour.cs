using UnityEngine;
using System.Collections;

public class Enemy1Behaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	public string weakness; // <-- tag van kogel waar hij niet tegen kan.

	void Update(){
		Movement ();

		if (this.transform.position.x < -6.7) {
			Destroy(this.gameObject);
		}
		
	}

	virtual protected void Movement(){
		transform.Translate (new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == weakness) {
			Debug.Log("auw!!");
            GetDamage(100);
		}
	}

	void GetDamage(float dmg){
        scriptEnemy.health -= dmg;
        if (scriptEnemy.health <= 0) {
			Death();
		}
	}

	void Death(){
		Destroy (this.gameObject);
	}
}

// Ga quads gebruiken als placeholder en 2d rigitbodies