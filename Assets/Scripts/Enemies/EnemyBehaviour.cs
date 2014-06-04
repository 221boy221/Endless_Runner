using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	public GameObject nextTransform;
	public GameObject deathAnim;

	public GameObject weakness; // <-- tag van kogel waar hij niet tegen kan.
	public GameObject strength; // <-- tag van kogel waar hij sterker van wordt.

    private PlayerXP playerXP;
	private PlayerHealth playerHealth;
    private PlayerKills playerKills;

	public AudioClip transformSound;

	private bool tfm = false;

	Animator anim;
	
	void Awake() {
        playerXP = GameObject.FindGameObjectWithTag("PlayerXPUI").GetComponent<PlayerXP>();
		playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
        playerKills = GameObject.FindGameObjectWithTag("PlayerKillsUI").GetComponent<PlayerKills>();
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

		if (other.gameObject.tag == "Player") {
			Attack();
		}
	}

	void GetStronger() {

		if (nextTransform != null && !tfm) {
			tfm = true;
			Vector2 offset = new Vector2(transform.position.x,transform.position.y + 0.15f);
			transform.position = offset;

			anim.Play("EnemyTransformation1");
			audio.clip = transformSound;
			audio.Play ();
			scriptEnemy.movementSpeed = 1.5f;
			Invoke ("TransformEnemy", 0.85f);

		}
	}

	void TransformEnemy() {
		Instantiate (nextTransform, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}

	void GetDamage (float dmg) {
        scriptEnemy.health -= dmg;
        if (scriptEnemy.health <= 0) {
			Death();
            playerXP.IncreaseValue(scriptEnemy.xpValue);
            playerKills.IncreaseValue(1);
		}
	}

	void Attack (){
		Debug.Log (scriptEnemy.attackDamage + " habba habba");
		playerHealth.TakeDamage (scriptEnemy.attackDamage);
	}

    public float Health {
        get { return scriptEnemy.health; }
    }


	void Death() {
		if (deathAnim != null) {
			Instantiate (deathAnim, this.transform.position, this.transform.rotation);
		}
		Destroy (this.gameObject);
	}
}

// Ga quads gebruiken als placeholder en 2d rigitbodies