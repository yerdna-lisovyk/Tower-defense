
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
        Gold = 1000;
    }
}
