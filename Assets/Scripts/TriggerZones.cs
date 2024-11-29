using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class TriggerZones : MonoBehaviour
{   
    public TMP_Text triggerText;
    public GameObject statueUnderline;
    public GameObject weaponHolder;

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && this.gameObject.name == "TriggerZone"){
            triggerText.SetText("SEE THAT CARD OVER THERE? THATS A HEALTH POWERUP. YOU CAN PICK IT UP WHEN YOUR HEALTH IS LESS THAN MAX.");
        }
        else if(other.tag == "Player" && this.gameObject.name == "TriggerZone1"){
            triggerText.SetText("THIS IS THE STATUE. PROTECT IT WITH YOUR LIFE OR YOU DIE.");
            statueUnderline.SetActive(true);
        }
        else if(other.tag == "Player" && this.gameObject.name == "TriggerZone2"){
            triggerText.SetText("KILL THAT SKELETON. PRESS YOUR LEFT MOUSE TO USE YOUR DAGGER.");
            weaponHolder.SetActive(true);
        }
        else if(other.tag == "Player" && this.gameObject.name == "TriggerZone3"){
            triggerText.SetText("KILL ALL THESE SKELETONS AT ONCE BY USING YOUR ULT ABILITY. PRESS RIGHT CLICK.");
            player.GetComponent<PlayerHandler>().CanAttack = true;
        }
        else if(other.tag == "Player" && this.gameObject.name == "TriggerZone4"){
            triggerText.SetText("THAT'S ALL YOU NEED TO KNOW. NOW GO.");
        }
        else if(other.tag == "Player" && this.gameObject.name == "TriggerZone5"){
            triggerText.SetText("WASD TO WALK. YOU CAN ALSO RUN WITH LSHIFT.");
        }
   
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag== "Player"){
            triggerText.SetText(" ");
            statueUnderline.SetActive(false);
        }
   
    }
}
