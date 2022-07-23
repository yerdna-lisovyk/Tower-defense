
using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    private int _gold;
    
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;
    private int wave;
    
    public Text healthLabel;
    public GameObject[] healthIndicator;
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            if (!gameOver)
            {
                foreach (var t in nextWaveLabels)
                {
                    t.GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            waveLabel.text = "WAVE: " + (wave + 1);
        }
    }
    
    public int Gold {
        get => _gold;
        set
        {
            _gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + _gold;
        }
    }

    private void Start()
    {
        Wave = 0;
        Health = 5;
        Gold = 1000;
    }
    
}
