using UnityEngine;
using System.Collections;

    // Boy Voesten

public class PlayerHealth : MonoBehaviour {

    private float _health = 100.0f;

    public void IncreaseHealth(float points) {
        _health += points;

        if (_health > 100) {
            _health = 100;
        } else if (_health <= 0) {
            Dead();
        }
    }

    void Dead() {
        Application.LoadLevel("gameOver");
    }
    
    public float GetHealth {
        get {
            return _health; 
        }
        set {
            _health = value;
        }
    }
}
