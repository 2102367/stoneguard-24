using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    public GameObject swarmerPrefab;
    private float swarmerInterval = 4.5f;

   void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Enemy");

        if(prefabInstances.Length <= 15){
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation);
        }
        if(prefabInstances.Length > 15){
            yield return null;
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
