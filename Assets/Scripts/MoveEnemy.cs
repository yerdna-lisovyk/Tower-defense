using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] waypoints;
    private int _currentWaypoint = 0;
    private float _lastWaypointSwitchTime;
    public float speed = 1.0f;

    private void Start()
    {
        _lastWaypointSwitchTime = Time.time;
    }

    private void Update()
    {
        Vector3 startPosition = waypoints [_currentWaypoint].transform.position;
        Vector3 endPosition = waypoints [_currentWaypoint + 1].transform.position;
        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - _lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition)) 
        {
            if (_currentWaypoint < waypoints.Length - 2)
            {
                _currentWaypoint++;
                _lastWaypointSwitchTime = Time.time;
                // TODO: поворачиваться в направлении движения
            }
            else
            {
                Destroy(gameObject);
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                // TODO: вычитать здоровье
            }
        }
    }
}
