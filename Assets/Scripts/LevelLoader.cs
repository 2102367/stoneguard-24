using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;


public class LevelLoader : MonoBehaviour
{
    public AudioMixer mixer;
    public GameStateManager gsm;
    public GameObject optionsCanvas;

    public GameObject menuCanvas;

    public float musicVolume;

    void Start(){
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        musicVolume = gsm.musicVolume;

    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void loadGame()
    {
        gsm.setLives(5);
        gsm.setScore(0);
        SceneManager.LoadScene("Play");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void loadTutorial()
    {
        gsm.setLives(5);
        gsm.setScore(0);
        SceneManager.LoadScene("Tutorial");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // public void resumeGame()
    // {
    //     SceneManager.LoadScene("Play");
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    //options

    public void loadOptions(){
        optionsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void backButton(){
        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
   
    // public void setVolume(float v){
    //     gsm.musicVolume = v;
    // }


}
