using UnityEngine;
using System.Collections;

public class Enemy1Behaviour : MonoBehaviour {

	public GlobalEnemyScript scriptEnemy;

	void Update(){
		Movement ();
	}

	void Movement(){
		transform.Translate (new Vector2(-scriptEnemy.movementSpeed,0)*Time.deltaTime,Space.World);
	}
}
