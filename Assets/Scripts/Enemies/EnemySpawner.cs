using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy1Num2;
	public GameObject enemy2Num2;

	public GameObject portal;

	int portalCounter;

	void Start() {

		Invoke("EnemySpawn",5f);
	}

	void SpawnEnemy(GameObject EnemyType) {
		if (EnemyType == enemy1 || EnemyType == enemy2) {
			Instantiate (EnemyType, new Vector2 (7, 0), this.transform.rotation);
		} else {
			Instantiate (EnemyType, new Vector2 (7, 0.15f), this.transform.rotation);
		}
	}

	void Spawn2Enemies(GameObject EnemyType1,GameObject EnemyType2){

		Instantiate(EnemyType1, new Vector2 (7, 0), this.transform.rotation);
		Instantiate(EnemyType2, new Vector2 (10, 0), this.transform.rotation);
	}

	void EnemySpawn() {

		int chooseSpawnType = Random.Range (1, 5);
		int chooseEnemyToSpawn = Random.Range(1, 3);

		Debug.Log(chooseEnemyToSpawn);
		if (chooseSpawnType == 1) {
			if (chooseEnemyToSpawn == 1) {
				SpawnEnemy (enemy1);
			} else if (chooseEnemyToSpawn == 2) {
				SpawnEnemy (enemy2);
			}						
		} else if (chooseSpawnType == 2) {
			if (chooseEnemyToSpawn == 1) {
				Spawn2Enemies (enemy1,enemy2);
			} else if (chooseEnemyToSpawn == 2) {
				Spawn2Enemies (enemy2,enemy1);
			}	
		}else if (chooseSpawnType == 3){
			if(chooseEnemyToSpawn == 1){
				SpawnEnemy(enemy1Num2);
			}else if(chooseEnemyToSpawn == 2){
				SpawnEnemy(enemy2Num2);
			}
		}else{
			portalCounter ++;
			if(portalCounter == 5){
				portalCounter = 0;
				Instantiate(portal, new Vector2 (4, 0.48f), this.transform.rotation);
			}
		}

		Invoke("EnemySpawn",Random.Range(5f - (portalCounter/2),7f - (portalCounter/2)));
	}
}
