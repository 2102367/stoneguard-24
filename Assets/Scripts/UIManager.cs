using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    // public TMP_Text waveTitleText;
    // public TMP_Text waveText;

    // public TMP_Text livesText;
    // public TMP_Text statueText;


    public GameObject lowHealthText;
    public GameObject lowHealthPanel;
    public GameObject statsCanvas;
    // public GameObject gameOverCanvas;

    public GameStateManager gsm;
    public HealthBar healthBar;
    public HealthBar statueBar;
    public HealthBar waveBar;

    void Start()
    {
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        healthBar.setMaxHealth(5);
        statueBar.setMaxHealth(10);
        waveBar.setMaxHealth(gsm.waveEnemyCount);
    }

    void Update()
    {
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().SetText("SCORE: " + (gsm.score*100));
        GameObject.Find("WaveTitle").GetComponent<TextMeshProUGUI>().SetText("WAVE " + gsm.wave);
        GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>().SetText("KILL " + (gsm.waveEnemyCount - gsm.enemiesKilled) + " MORE TO GET TO NEXT WAVE");


        // GameObject.Find("LivesText").GetComponent<TextMeshProUGUI>().SetText("LIVES: " + gsm.lives);
        // GameObject.Find("StatueText").GetComponent<TextMeshProUGUI>().SetText("STATUE HEALTH: " + gsm.statueLives);

        healthBar.setHealth(gsm.getLives());
        statueBar.setHealth(gsm.getStatueLives());
        waveBar.setHealth(gsm.getEnemiesKilled());

    
        if (gsm.lives <= 2) {
            // Debug.Log("Low Health!");
            lowHealthText.SetActive(true);
            lowHealthPanel.SetActive(true);
        }
        
        if(gsm.lives > 2){
            // gameOverCanvas.SetActive(false);
            statsCanvas.SetActive(true);
            lowHealthText.SetActive(false);
            lowHealthPanel.SetActive(false);
        }

    }
}
