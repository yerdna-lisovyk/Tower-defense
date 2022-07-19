using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject _monster;
    
    private bool CanPlaceMonster()
    {
        return _monster == null;
    }

    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            //3
            _monster = (GameObject) 
                Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            //4
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // TODO: вычитать золото
        } else if (CanUpgradeMonster())
        {
            _monster.GetComponent<MonsterData>().IncreaseLevel();
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            
            // TODO: вычитать золото
        }
    }
    private bool CanUpgradeMonster()
    {
        if (_monster == null) return false;
        var monsterData = _monster.GetComponent<MonsterData>();
        var nextLevel = monsterData.GetNextLevel();
        return nextLevel != null;
    }
}
