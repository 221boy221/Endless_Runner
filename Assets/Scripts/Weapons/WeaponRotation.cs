using UnityEngine;
using System.Collections;

public class WeaponRotation : MonoBehaviour {

    private float nextFireTime;
    public float fireRate = 0.2f;
    protected bool paused = false;

	// Reload variables
	private float maxAmmo = 5;
	private float ammo;
	private float reloadTime = 1.5f;
	private float counter;
	private bool reloading = false;

    public GameObject bullet1;//hieronder staan alle kogels van alle wapens.
    Vector2 mousePos;


	void Awake() {
		ammo = maxAmmo;
	}

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (!paused) ? true : false;  // This is basically: if (paused = true) paused = false; else paused = true;
    }

	void Update() {
        if (!paused) { // If the game is not paused, continue.

		    Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position); // <-- hier bereken ik de positie van de speler in de camera view
		
		    mousePos.x = Input.mousePosition.x - objectPos.x; // in de x van de vector 2 van de variable mousePos stop ik de x van de muis - de x van de speler waar hij zich op het scherm bevind.
		    mousePos.y = Input.mousePosition.y - objectPos.y; // in de y van de vector 2 van de variable mousePos stop ik de y van de muis - de y van de speler waar hij zich op het scherm bevind.

		    float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // de hoek(angle) bereken ik met wat we bij wiskunde hadden geleerd die dag. de atan2 functie en dan Rad2Deg(* 180 / PI)

		    // Voorkomt bugs in bewegingen
		    transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle)); // hier stop ik de rotatie in actie door de waarde van de rotation te veranderen 

            // Shooting the projectiles. It has a cooldown and you can hold down the mouse button this way.
            if (Input.GetMouseButton(0) && Time.time > nextFireTime) {
				if (ammo > 0) {
					SchootBullet();
				} else if (ammo <= 0 && !reloading) {
					Reload();
				}
		    }
			// tijd dat de speler aan het reloaden is. De groter de var reloadSpeed. De langer de tijd van reloaden.
			if (reloading) {
				counter -= Time.deltaTime;
				Debug.Log(counter);
				if (counter <= 0) {
					ammo = maxAmmo;
					reloading = false;
				}
			}
        }
	}
	
	void SchootBullet() {
        nextFireTime = Time.time + fireRate; // This adds the delay
		ammo --;
		Debug.Log (ammo);
        Instantiate (bullet1,new Vector3(transform.position.x,transform.position.y, transform.position.z + 0.1f), this.transform.rotation); // hier word de kogel gemaakt. kijk in het kogel script hoe ik hem laat bewegen.("bulletsScript") ^^  
	}

	void Reload () {
		reloading = true;
		counter = reloadTime;
	}
}