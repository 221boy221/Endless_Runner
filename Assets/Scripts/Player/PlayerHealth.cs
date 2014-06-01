using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private float health = 100.0f;

    public void TakeDamage(float dmg) {
        health -= dmg;

        if (health <= 0) {
            Dead();
        }
    }

    void Dead() {
        Debug.Log("You are dead.");
        Application.LoadLevel("gameOver");
    }

    public float Health {
        get { return health; }
    }
}
