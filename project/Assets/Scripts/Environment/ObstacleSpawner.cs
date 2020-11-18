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
    public int spawnCount = 0;
    private bool spawnnow = true;

    int laneSelect;
    private List<int> usedLanes;

    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;

    private void Start()
    {
        usedLanes = new List<int>();
    }

    void Update()
    {
        
        if (spawnCount >= 2)
        {
            spawnnow = false;
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnnow = true;
            spawnTimer = 0;
        }

        if (spawnTimer >= (20f / spawnDelay.m_Value) + 1.0f)
        {
            spawnTimer = 0;
            spawnnow = true;
        }
        
        if (spawnnow)
        {
            if (usedLanes.Count > 0)
            {
                switch (usedLanes[0])
                {
                    case 1:
                        leftRepeats = repeatAllowed;
                        break;
                    case 2:
                        middleRepeats = repeatAllowed;
                        break;
                    case 3:
                        rightRepeats = repeatAllowed;
                        break;
                }
            }

            // left lane
            laneSelect = Random.Range(1, 4);
            if (laneSelect == 1 && leftRepeats <= repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], left.transform);
                leftRepeats++;
                rightRepeats = 0;
                middleRepeats = 0;
                int nleft = 1;
                usedLanes.Add(nleft);
            }
            // middle lane
            else if (laneSelect == 2 && middleRepeats <= repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], middle.transform);
                middleRepeats++;
                leftRepeats = 0;
                rightRepeats = 0;
                int nmiddle = 1;
                usedLanes.Add(nmiddle);
            }
            // right lane
            else if (laneSelect == 3 && rightRepeats <= repeatAllowed)
            {
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], right.transform);
                rightRepeats++;
                leftRepeats = 0;
                middleRepeats = 0;
                int nright = 1;
                usedLanes.Add(nright);
            }
            if (usedLanes.Count > 0)
            {
                usedLanes.RemoveAt(0);
            }
                spawnnow = false;
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
