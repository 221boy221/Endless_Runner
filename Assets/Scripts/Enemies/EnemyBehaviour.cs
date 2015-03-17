using UnityEngine;
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

    private PlayerData playerData;
    private PlayerHealth playerHealth;
	private Animator anim;
	private AudioControll ac;
    private bool tfm = false;

	void Awake() {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
		ac = GameObject.FindGameObjectWithTag ("AudioController").GetComponent<AudioControll> ();
		playerHealth = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<PlayerHealth>();
		anim = GetComponent<Animator>();
	}


	void Update() {
		Movement();

		if (this.transform.position.x < -11) {
			Destroy(gameObject);
		}
	}

	virtual protected void Movement() {
		transform.Translate (new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == weakness.gameObject.tag) {
			GetDamage(other.gameObject.GetComponent<BulletsScript>().damage);
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
            /*
			Vector2 offset = new Vector2(transform.position.x,transform.position.y + 0.15f);
			transform.position = offset;
            */
			anim.Play("EnemyTransformation1");
			GetComponent<AudioSource>().clip = transformSound;
			GetComponent<AudioSource>().Play ();
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
            playerData.IncreaseXP(scriptEnemy.xpValue);
            playerData.IncreaseKills(1);
		}
	}

	void Attack() {
		ac.PlayAudio (ac.attacksound);
		playerHealth.IncreaseHealth(-scriptEnemy.attackDamage);

	}

    public float Health {
        get { 
            return scriptEnemy.health; 
        }
    }

	void Death() {
		if (deathAnim != null) {
			Instantiate (deathAnim, this.transform.position, this.transform.rotation);
		}
		Destroy (this.gameObject);
	}
}
