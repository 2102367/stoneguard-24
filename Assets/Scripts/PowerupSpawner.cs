using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject healthPrefab;
    private float healthInterval = 4f;

   void Start()
    {
        StartCoroutine(spawnHealth(healthInterval, healthPrefab));
    }

    //countdown for spawning health objects
    private IEnumerator spawnHealth(float interval, GameObject enemy){
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Health");

        if(prefabInstances.Length <= 3){
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation);
        }
        if(prefabInstances.Length > 3){
            yield return null;
        }

        StartCoroutine(spawnHealth(interval, enemy));
    }
}
