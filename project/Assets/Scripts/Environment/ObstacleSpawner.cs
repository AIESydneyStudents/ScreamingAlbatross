using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject middle;
    [SerializeField] GameObject right;

    [SerializeField] GameObject ObstaclePrefab;
    [SerializeField] int repeatAllowed;
    
    [SerializeField] float spawnChargeTimer;
    
    [SerializeField] float spawnDelay;
    float spawnTimer;
    private int spawnCount = 3;

    int laneSelect;

    bool leftUsed = false;
    bool rightUsed = false;
    bool middleUsed = false;


    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;

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
            if (laneSelect >= 50 && laneSelect < 100 && middleRepeats < repeatAllowed )
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
