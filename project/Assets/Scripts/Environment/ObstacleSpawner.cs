using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject middle;
    [SerializeField] GameObject right;

    [SerializeField] GameObject[] Obstacles;
    [SerializeField] int repeatAllowed;
    
    [SerializeField] public ScriptableFloat spawnDelay;
    public float spawnTimer;
    public int spawnCount = 3;

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

        if (spawnTimer > (25f / spawnDelay.m_Value))
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
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], left.transform);
                leftRepeats++;
                rightRepeats = 0;
                middleRepeats = 0;
            }
            if (laneSelect >= 50 && laneSelect < 100 && middleRepeats < repeatAllowed )
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], middle.transform);
                middleRepeats++;
                leftRepeats = 0;
                rightRepeats = 0;
            }
            if (laneSelect >= 100 && rightRepeats < repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], right.transform);
                rightRepeats++;
                leftRepeats = 0;
                middleRepeats = 0;

            }
        }
    }
   

}
