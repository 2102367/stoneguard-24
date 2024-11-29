using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{   
    public GameObject swarmerPrefab;
    private float swarmerInterval = 6.0f;

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Enemy");

        if(prefabInstances.Length <= 3){
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation);
        }
        if(prefabInstances.Length > 3){
            yield return null;
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
