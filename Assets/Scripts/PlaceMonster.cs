using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;
    
    private bool CanPlaceMonster()
    {
        return monster == null;
    }

    private void OnMouseUp()
    {
        if (!CanPlaceMonster()) return;
        monster = (GameObject) 
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        var audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);

        // TODO: вычитать золото
    }
}
