using UnityEngine;
using System.Collections;

    // Boy Voesten
    // Ramses Di Perna

public class WeaponRotation : MonoBehaviour {
    
    protected bool paused = false;

    Vector2 mousePos;

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (!paused) ? true : false;
    }

	void Update() {
        if (paused) return;
        
        UpdateWeaponRot();
    }

    void UpdateWeaponRot() {
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position); // Calculating the position of the player using pixels
		
        mousePos.x = Input.mousePosition.x - objectPos.x;
        mousePos.y = Input.mousePosition.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
    }
	
}