using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;

	void Start () {

		Invoke ("EnemySpawn",5f);
	}

	void SpawnEnemy(GameObject EnemyType){

		Instantiate (EnemyType, new Vector2 (7, 0), this.transform.rotation);
	}

	void EnemySpawn(){

		int chooseEnemyToSpawn = Random.Range (1, 3);
		Debug.Log (chooseEnemyToSpawn);
		if (chooseEnemyToSpawn == 1) {
			SpawnEnemy(enemy1);
		} else if (chooseEnemyToSpawn == 2) {
			SpawnEnemy(enemy2);
		}
		Invoke ("EnemySpawn",Random.Range(3f,6f));
	}
}
