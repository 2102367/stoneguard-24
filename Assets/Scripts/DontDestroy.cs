using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject[] instances = GameObject.FindGameObjectsWithTag("GSM");
        if (instances.Length > 1){
            Destroy(this.gameObject);
        } 

    }

}
