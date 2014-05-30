using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	public GameObject nextTransform;

	public GameObject weakness; // <-- tag van kogel waar hij niet tegen kan.
	public GameObject strength; // <-- tag van kogel waar hij sterker van wordt.

    private PlayerXP playerXP;

	Animator anim;

	float maxHealthBegin;
	
	void Awake() {
        playerXP = GameObject.FindGameObjectWithTag("PlayerXPUI").GetComponent<PlayerXP>();
		anim = GetComponent<Animator>();
	}


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
			//BulletsScript bs = other.GetComponent<BulletsScript>() as BulletsScript);
			GetDamage(BulletsScript.damage);
		} else if (other.gameObject.tag == strength.gameObject.tag) {
			Debug.Log("Hit by strength - My power is rising!");
			GetStronger();
		}
	}

	void GetStronger() {
		//TransformEnemy("health");
		if (nextTransform != null) {
			anim.Play("EnemyTransformation1");
			scriptEnemy.movementSpeed = 1.5f;
			Invoke ("TransformEnemy", 1f);
		}
	}

	void TransformEnemy() {

		Instantiate (nextTransform, new Vector2(this.transform.position.x,this.transform.position.y +0.17f), this.transform.rotation);
		Destroy (this.gameObject);
	}

	void GetDamage (float dmg) {
        scriptEnemy.health -= dmg;
        if (scriptEnemy.health <= 0) {
			Death();
            playerXP.IncreaseValue(100);
		}
	}

	void Death() {
		Destroy (this.gameObject);
	}
}

// Ga quads gebruiken als placeholder en 2d rigitbodies