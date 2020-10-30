﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject middle;
    [SerializeField] GameObject right;

    [SerializeField] GameObject road;

    [SerializeField] GameObject ObstaclePrefab;
    [SerializeField] int repeatAllowed;
    //this is having a "limit" on the spawns, its max of 2 spawns per set
    //interval so the obstacles at most spawn twice at a certain point so 
    //the game isnt impossible at times.
    [SerializeField] float spawnChargeTimer;
    //when the spawnTimer hits the spawnchargetimer amount the spawncount will -1
    //so another object can be spawned
    [SerializeField] float spawnDelay;
    float spawnTimer;
    private int spawnCount = 3;

    public float roadSpawnTime = 0.622f;
    private float roadTimer;
    int laneSelect;

    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;

    void Update()
    {
        roadTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (roadTimer >= roadSpawnTime)
        {
            Instantiate(road, transform);
            roadTimer = 0;
        }

        if (spawnTimer > spawnChargeTimer)
        {
            spawnCount--;
            spawnTimer = 0;
        }

        if (spawnCount <= 2)
        {
            spawnCount++;
            laneSelect = Random.Range(0, 150);
            if (laneSelect < 50 && leftRepeats < repeatAllowed)
            {
                Instantiate(ObstaclePrefab, left.transform);
                leftRepeats++;
                rightRepeats = 0;
                middleRepeats = 0;
            }
            if (laneSelect >= 50 && laneSelect < 100 && middleRepeats < repeatAllowed)
            {
                Instantiate(ObstaclePrefab, middle.transform);
                middleRepeats++;
                leftRepeats = 0;
                rightRepeats = 0;
            }
            if (laneSelect >= 100 && rightRepeats < repeatAllowed)
            {
                Instantiate(ObstaclePrefab, right.transform);
                rightRepeats++;
                leftRepeats = 0;
                middleRepeats = 0;
            }
        }
    }
    
}
