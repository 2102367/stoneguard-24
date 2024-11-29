using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class SwordCollisionDetection : MonoBehaviour
{

    public WeaponController wc;
    public GameObject HitParticle;

    public GameStateManager gsm;
    public int swordPower;

    void Start()
    {   
        swordPower = 1;
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Enemy" && wc.IsAttacking){
            // Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            // gsm.adjustScore(1);
            other.GetComponent<EnemyScript>().adjustHealth(swordPower);
            // other.GetComponent<NavMeshAgent>().isStopped = true;
            // StartCoroutine(StopForSeconds(2f));
            HitParticle.GetComponent<ParticleSystem>().Play();
            HitParticle.GetComponent<AudioSource>().Play();
            // Instantiate(HitParticle, other.transform.position, other.transform.rotation);
        }

    }

    //for nav mesh agents stopping animations and starting again -- tested and doesnt currently work
    // void StopAndResetAgent()
    // {
    //     agent.isStopped = true;
    //     agent.ResetPath();
    // }

    // void OnTriggerExit(Collider other){

    //     other.GetComponent<NavMeshAgent>().ResetPath();
    // }

}
