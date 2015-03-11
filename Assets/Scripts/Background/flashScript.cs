using UnityEngine;
using System.Collections;

// Gemaakt door Ramses

public class flashScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Destroy(this.gameObject, 3.5f);
    }

}