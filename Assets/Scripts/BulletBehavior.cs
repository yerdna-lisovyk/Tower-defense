using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float _distance;
    private float _startTime;

    private GameManagerBehavior _gameManager;

    private void Start()
    {
        _startTime = Time.time;
        _distance = Vector2.Distance (startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        _gameManager = gm.GetComponent<GameManagerBehavior>();
    }
}
