using UnityEngine;
using System.Collections;

// Gemaakt door Ramses

public class movingBack : MonoBehaviour {

	public float speed = 0;
	public static movingBack current;

	float pos = 0;

	// Use this for initialization
	void Start () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed * Time.deltaTime;
		if(pos > 1.0f)
			pos = 0f;

		renderer.material.mainTextureOffset = new Vector2(pos,0);
	}
	
}
