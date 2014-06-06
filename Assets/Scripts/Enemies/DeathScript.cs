using UnityEngine;
using System.Collections;

// Gemaakt door Ramses

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float voicePitch = Random.Range (0.9f, 1.4f);
		audio.pitch = voicePitch;
		Destroy (this.gameObject, 1f);
	}
}
