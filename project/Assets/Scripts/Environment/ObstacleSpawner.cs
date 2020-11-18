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

    public float spawnTimer;
    public int spawnCount = 0;

    int laneSelect;

    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;

    void Update()
    {
        if (spawnCount < 1)
        {
            SpawnNow();
        }
    }

    void SpawnNow()
    {
        // left lane
        laneSelect = Random.Range(1, 4);
        if (laneSelect == 1 && leftRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], left.transform);
            leftRepeats++;
            rightRepeats = 0;
            middleRepeats = 0;
        }
        // middle lane
        else if (laneSelect == 2 && middleRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], middle.transform);
            middleRepeats++;
            leftRepeats = 0;
            rightRepeats = 0;
        }
        // right lane
        else if (laneSelect == 3 && rightRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], right.transform);
            rightRepeats++;
            leftRepeats = 0;
            middleRepeats = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            spawnCount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            spawnCount--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            spawnCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            spawnCount--;
        }
    }

}