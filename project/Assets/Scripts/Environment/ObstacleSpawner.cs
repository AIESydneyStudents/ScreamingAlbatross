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
    private bool spawnnow = true;

    int laneSelect;

    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;

    void Update()
    {
        if (spawnCount <= 2)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnTimer = 0;
        }

        if (spawnTimer >= (20f / spawnDelay.m_Value))
        {
            spawnTimer = 0;
            spawnnow = true;
        }
        else if (spawnnow)
        {
            laneSelect = Random.Range(1, 3);
            if (laneSelect == 1 && leftRepeats < repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], left.transform);
                leftRepeats++;
                rightRepeats = 0;
                middleRepeats = 0;
            }
            if (laneSelect == 2 && middleRepeats < repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], middle.transform);
                middleRepeats++;
                leftRepeats = 0;
                rightRepeats = 0;
            }
            if (laneSelect == 3 && rightRepeats < repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], right.transform);
                rightRepeats++;
                leftRepeats = 0;
                middleRepeats = 0;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            spawnCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            spawnCount--;
        }
    }

}
