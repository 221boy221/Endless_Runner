﻿using UnityEngine;
using System.Collections;

// Gemaakt door grootendeels Ramses en kleine toevoeging Boy

public class EnemyBehaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;
	public GameObject nextTransform;
	public GameObject deathAnim;
	public GameObject weakness;
	public GameObject strength;
    public AudioClip transformSound;
	public AudioClip attackSound;

    private PlayerXP playerXP;
	private PlayerHealth playerHealth;
    private PlayerKills playerKills;
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
		transform.Translate(new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == weakness.gameObject.tag) {
			//BulletsScript bs = other.GetComponent<BulletsScript>() as BulletsScript);
			GetDamage(BulletsScript.damage);
		} else if (other.gameObject.tag == strength.gameObject.tag) {
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

	void GetDamage(float dmg) {
        scriptEnemy.health -= dmg;
        if (scriptEnemy.health <= 0) {
			Death();
            playerXP.IncreaseValue(scriptEnemy.xpValue);
            playerKills.IncreaseValue(1);
		}
	}

	void Attack() {
		audio.clip = attackSound;
		audio.volume = 0.5f;
		audio.Play();
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
