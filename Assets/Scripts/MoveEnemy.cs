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
                RotateIntoMoveDirection();
            }
            else
            {
                Destroy(gameObject);
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                GameManagerBehavior gameManager =
                    GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;
            }
        }
    }
    
    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = waypoints [_currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints [_currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position, 
            waypoints [_currentWaypoint + 1].transform.position);
        for (int i = _currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints [i].transform.position;
            Vector3 endPosition = waypoints [i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
