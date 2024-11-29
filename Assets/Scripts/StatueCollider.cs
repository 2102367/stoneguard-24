using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCollider : MonoBehaviour
{
    private int Health;
    public GameStateManager gsm;

    
    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        // Health = 10;
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Enemy"){
            gsm.adjustStatueLives(1);
            // Debug.Log(Health);
            if(gsm.statueLives == 0){
                gsm.gameOver();
            }
        }

    }
}
