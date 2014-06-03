using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
	}
}
