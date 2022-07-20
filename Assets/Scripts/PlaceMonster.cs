using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject _monster;
    private GameManagerBehavior _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private bool CanPlaceMonster()
    {
        var cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        return _monster == null && _gameManager.Gold >= cost;
    }
    private bool CanUpgradeMonster()
    {
        if (_monster == null) return false;
        var monsterData = _monster.GetComponent<MonsterData>();
        var nextLevel = monsterData.GetNextLevel();
        return _gameManager.Gold>= nextLevel.cost;
    }
    private void OnMouseUp()
    {
        if (CanPlaceMonster())
        {
            _monster = (GameObject) 
                Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            _gameManager.Gold -= _monster.GetComponent<MonsterData>().CurrentLevel.cost;
        } else if (CanUpgradeMonster())
        {
            _monster.GetComponent<MonsterData>().IncreaseLevel();
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            
            _gameManager.Gold -= _monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }
    }

}
