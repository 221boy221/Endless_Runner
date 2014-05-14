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
		if (scriptEnemy.health <= 0) {
			Death();
		}
	}

	virtual protected void Movement(){
		transform.Translate (new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == weakness) {
			Debug.Log("auw!!");
		}
	}

	void GetDamage(float dmg){

	}

	void Death(){
		Destroy (this.gameObject);
	}
}
