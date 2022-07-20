
using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    private int _gold;
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
        Gold = 1000;
    }
}
