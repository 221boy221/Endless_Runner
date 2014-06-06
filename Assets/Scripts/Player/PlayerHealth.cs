using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private float health = 100.0f;
    public float GetHealth { get { return health; } }

    public void TakeDamage(float dmg) {
        health -= dmg;

        if (health <= 0) {
            Dead();
        }
    }
    public void SetHealth(float hp) {
        health = hp;
    }
    public void IncreaseHealth(float hp) {
        health += hp;
        if (health > 100) {
            health = 100;
        }
    }
    
    void Dead() {
        Debug.Log("You are dead.");
		BulletsScript.damage = 50f;
        Application.LoadLevel("gameOver");
    }
}
