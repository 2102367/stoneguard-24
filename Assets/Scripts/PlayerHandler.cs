using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PlayerHandler : MonoBehaviour
{
    private Camera cam;
    public GameStateManager gsm;
    // public GameObject upgradeScreen;
    // public GameObject stats;
    public GameObject weaponHolder;


    public bool CanAttack = true;
    public float AttackCooldown = 10f;
    public AudioClip magicAttackSound;

    public AudioSource ac;
    public bool IsAttacking = false;

    public AudioClip backgroundMusic;

    
    void Start()
    {
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        cam = GameObject.Find("First Person Camera").GetComponent<Camera>();
        ac = GetComponent<AudioSource>();

        ac.PlayOneShot(backgroundMusic);

    }

    void Update()
    {   
        //for custom volume settings
        ac.volume = gsm.musicVolume;

        //for magic attack
        if(Input.GetMouseButtonDown(1)){
            if(CanAttack){
                magicAttack();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        //player collisions
        if(other.tag == "Enemy"){
            gsm.adjustLives(1);
            if(gsm.lives < 1){
                gsm.CheckGameOver();
            }
        }

        if(other.tag == "Health"){
            if(gsm.lives < 5){
                gsm.setLives(gsm.lives + 1);
                Destroy(other.gameObject);
            }
            // else if(gsm.lives > 5){
            //     Debug.Log("Max health reached, can't pick up any more health.");
            // }

        }

        if(other.tag == "PortalToPlay"){
            SceneManager.LoadScene("Play");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }      
    }

    //magic attack , first checking if we can attack then setting trigger for animation
    public void magicAttack(){
        Debug.Log("Magic attack!");
        IsAttacking = true;
        CanAttack = false;
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject prefab in prefabInstances){
            Destroy(prefab);
            gsm.adjustScore(1);
        }
        ac.PlayOneShot(magicAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    //cooldown for magic attack
    IEnumerator ResetAttackCooldown(){
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool(){
        yield return new WaitForSeconds(0.5f);
        IsAttacking = false;
    }

    //for upgrades --  tested it and currently doesnt work

    // private void OpenUpgradeScreen()
    // {
    //     upgradeScreen.SetActive(true);
    //     stats.SetActive(false);
    //     weaponHolder.SetActive(false);
    //     Cursor.lockState = CursorLockMode.None;
    //     Cursor.visible = true;       
    // }

    // public void CloseUpgradeScreen()
    // {
    //     upgradeScreen.SetActive(false);
    //     stats.SetActive(true);
    //     weaponHolder.SetActive(true);
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }
}
