using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown;
    public AudioClip SwordAttackSound;
    public bool IsAttacking = false;
    public GameObject HitBox;

    public GameStateManager gsm;

    void Start(){
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        AttackCooldown = gsm.swordAttackSpeed;

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(CanAttack){
                SwordAttack();
            }
        }
        AttackCooldown = gsm.swordAttackSpeed;

        // if(gsm.wave == 2 || gsm.wave == 4 || gsm.wave == 6){
        //     AttackCooldown += 0.5f;
        // }
    }

    //sword attack , first checking if we can attack then setting trigger for animation
    public void SwordAttack(){
        HitBox.SetActive(true);
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    //cooldown for sword attack
    IEnumerator ResetAttackCooldown(){
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool(){
        yield return new WaitForSeconds(0.5f);
        IsAttacking = false;
        HitBox.SetActive(false);
    }
}
