using UnityEngine;
using System.Collections;

public class WeaponRotation : MonoBehaviour {

	//hieronder staan alle kogels van alle wapens.
	public GameObject bullet1;
    
    private float fireRate = 0.2f;
    private float nextFireTime;

    protected bool paused = false;

    Vector2 mousePos;

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (!paused) ? true : false;  // This is basically: if (paused = true) paused = false; else paused = true;
    }

	void Update () {
        if (!paused) { // If the game is not paused, continue.
            // Je hoeft niet de camera een public variable te maken. Hiermee kan je hem aanspreken en voorkom je errors als je de speler moet weghalen.
		    Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position); // <-- hier bereken ik de positie van de speler in de camera view
		
		    mousePos.x = Input.mousePosition.x - objectPos.x; // in de x van de vector 2 van de variable mousePos stop ik de x van de muis - de x van de speler waar hij zich op het scherm bevind.
		    mousePos.y = Input.mousePosition.y - objectPos.y; // in de y van de vector 2 van de variable mousePos stop ik de y van de muis - de y van de speler waar hij zich op het scherm bevind.

		    float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // de hoek(angle) bereken ik met wat we bij wiskunde hadden geleerd die dag. de atan2 functie en dan Rad2Deg(* 180 / PI)

		    //(ik weet niet precies wat de "Quaternion.Euler" doet maar ik had gelezen dat dat de z stuf extra fixte en bugs voorkwam)
		    transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle)); // hier stop ik de rotatie in actie door de waarde van de rotation te veranderen 

		    //Hieronder is een placeholder voor het schieten. Er moet een cooldown etc etc komen maar het was alleen voor het uittesten.
            if (Input.GetMouseButton(0) && Time.time > nextFireTime) {
			    SchootBullet();
		    }
        }
	}
	
	void SchootBullet() {
        nextFireTime = Time.time + fireRate;
        Instantiate (bullet1, this.transform.position, this.transform.rotation); // hier word de kogel gemaakt. kijk in het kogel script hoe ik hem laat bewegen.("bulletsScript") ^^  
	}
	
}
