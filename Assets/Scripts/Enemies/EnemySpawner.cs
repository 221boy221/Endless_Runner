using UnityEngine;
using System.Collections;

// Gemaakt door Ramses
// Modified by Boy Voesten

public class EnemySpawner : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject[] enemies;
    public GameObject[] enemiesV2;
    public GameObject portal;

	private int portalCounter;

    // SpawnMultiple before starting to spawn
	void Start() {
		Invoke("EnemySpawn",5f);
	}

    // Choose enemy to spawn
	void EnemySpawn() {
		int spawnType = Random.Range (1, 5);
		int chosenEnemy = Random.Range(0, enemies.Length);

        switch (spawnType) {
            case 1: // Spawn 1 enemy
                SpawnEnemy(enemies[chosenEnemy]);
                break;
            case 2: // Spawn 2 enemies
                int chosenEnemy2 = Random.Range(0, enemies.Length);
                StartCoroutine(SpawnMultiple(enemies[chosenEnemy], enemies[chosenEnemy2]));
                break;
            case 3: // Spawn 1 enemy v2
                chosenEnemy = Random.Range(0, enemiesV2.Length);
                SpawnEnemy(enemiesV2[chosenEnemy]);
                break;
            default:
                SpawnEnemy(enemies[chosenEnemy]);
                break;
        }

        // Portal spawn system
        portalCounter++;
        
        if (portalCounter == 8) {
            portalCounter = 0;
            Instantiate(portal, spawnPoint.transform.position, transform.rotation);
        }

        // Repeat function
		Invoke("EnemySpawn",  Random.Range(6f - portalCounter / 2, 8f - portalCounter / 2) );
	}

    // Spawn the given enemy
    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
    }

    // Spawn the given enemies, with delay in between
    IEnumerator SpawnMultiple(GameObject enemy, GameObject enemy2) {
        Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(enemy2, spawnPoint.transform.position, transform.rotation);
    }
}
