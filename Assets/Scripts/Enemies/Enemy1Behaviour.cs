using UnityEngine;
using System.Collections;

public class Enemy1Behaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	public GameObject weakness; // <-- tag van kogel waar hij niet tegen kan.
	public GameObject strength; // <-- tag van kogel waar hij sterker van wordt.

	//enum transformOptions{health};

	float maxHealthBegin;
	
	void Start(){

		maxHealthBegin = scriptEnemy.maxHealth;
	}

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
		if (other.gameObject.tag == weakness.gameObject.tag) {
			Debug.Log ("auw!!");
			GetDamage (100);
		} else if (other.gameObject.tag == strength.gameObject.tag) {
			Debug.Log("My power is rising!");
			GetStronger();
		}
	}

	void GetStronger(){
		TransformEnemy("health");
	}

	void TransformEnemy(string transformType){
		if (transformType == "health") {
			if (scriptEnemy.maxHealth == maxHealthBegin) {
				scriptEnemy.maxHealth = scriptEnemy.maxHealth * 2;
				scriptEnemy.health = scriptEnemy.maxHealth;
			}else if(scriptEnemy.health < scriptEnemy.maxHealth){
				scriptEnemy.health += scriptEnemy.maxHealth / 4;
			}
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