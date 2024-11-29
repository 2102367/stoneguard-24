using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using Unity.VisualScripting;

public class GameStateManager : MonoBehaviour
{
    public int score;
    public int lives;
    public int statueLives;
    public int wave;
    public int enemiesKilled;
    public int waveEnemyCount;
    public float musicVolume;
    public float swordAttackSpeed;
    
    
    // public TMP_Text scoreText;
    // public TMP_Text livesText;
    

    void Start(){
        musicVolume = 0.2f;
        setLives(5);
        setStatueLives(10);
        setWave(1);
        setEnemiesKilled(0);
        waveEnemyCount = 10;
        swordAttackSpeed = 0.5f;
    }

    void Update(){
        if(enemiesKilled == waveEnemyCount){
            setEnemiesKilled(0);
            setWave(getWave() + 1);
            Debug.Log("Current wave is: " + wave);
            waveEnemyCount += 5;
            setStatueLives(10);
            swordAttackSpeed -= 0.1f;
        }
    }


    public void CheckGameOver() {
        if (lives < 1) {
            // Debug.Log("Game Over! Loading Menu scene.");
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void gameOver() {
        Debug.Log("Restarting game. Loading Play scene.");
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //scoring system
    public int getScore() {
        return score;
    }

    public void setScore (int s) {
        score = s;
    }

    public void adjustScore (int s) {
        score += s;
        //Debug.Log("Score is " + score);
    }

    //lives system
    public int getLives() {
        return lives;
    }

    public void setLives (int l){
        lives = l;
        CheckGameOver();
    }

    public void adjustLives(int l){
        lives -= l;
    }

    public int getStatueLives() {
        return statueLives;
    }

    public void adjustStatueLives(int l){
        statueLives -= l;
    }

    public void setStatueLives(int l){
        statueLives = l;
        CheckGameOver();
    }

    //waves system
    public int getWave() {
        return wave;
    }

    public void setWave(int w){
        wave = w;
    }

    public void adjustWave(int w){
        wave += w;
    }

    //enemies killed system
    public int getEnemiesKilled() {
        return enemiesKilled;
    }

    public void setEnemiesKilled(int e){
        enemiesKilled = e;
    }

    public void adjustEnemiesKilled(int e){
        enemiesKilled += e;
    }


    //options settings
    
    public void setVolume(float v){
        musicVolume = v;
    }
    

    //upgrade system -- ultimately scrapped because it wasn't working

    // public void upgradeStats(int lifeStat, int speedStat, int swordStat){
    //     lives += lifeStat;
    //     GameObject.Find("Player").GetComponent<FirstPersonMovement>().speed += speedStat;
    //     GameObject.Find("Dagger").GetComponent<SwordCollisionDetection>().swordPower += swordStat;
    // }

    

}
