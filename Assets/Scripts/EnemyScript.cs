using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int Health;
    public GameStateManager gsm;

    void Awake(){
        Health = 3;
    }
    
    public void adjustHealth(int s){
        // Debug.Log("1 Damage dealt");
        Health -= s;
    }

    void Start(){
       gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();

    }

    void Update(){
        if(Health == 0){
            gsm.adjustScore(1);
            gsm.adjustEnemiesKilled(1);
            Destroy(this.gameObject);
        }
    }
}
