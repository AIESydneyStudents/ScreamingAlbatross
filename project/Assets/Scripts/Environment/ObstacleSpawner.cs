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
    [SerializeField] GameObject[] PickUps;
    [SerializeField] int repeatAllowed;

    private List<GameObject> ExistingPickups = new List<GameObject>();

    public float spawnTimer;
    public int spawnCount = 0;
    public float pickupTimer = 1f;
    private float timer = 0f;

    int laneSelect;

    int leftRepeats = 0;
    int rightRepeats = 0;
    int middleRepeats = 0;
    int usedLane = 0;

    void FixedUpdate()
    {
        if (spawnCount < 1)
        {
            SpawnNow();
        }

        if (timer >= pickupTimer)
        {
            timer = 0;
            SpawnPickup();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpawnNow()
    {
        laneSelect = usedLane;
        while (laneSelect == usedLane)
        {
            laneSelect = Random.Range(1, 4);
        }

        if (laneSelect == 1 && leftRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], left.transform.position, left.transform.rotation);
            leftRepeats++;
            rightRepeats = 0;
            middleRepeats = 0;
            int nLeft = 1;
            usedLane = 1;
        }
        // middle lane
        else if (laneSelect == 2 && middleRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], middle.transform.position, middle.transform.rotation);
            middleRepeats++;
            leftRepeats = 0;
            rightRepeats = 0;
            int nMiddle = 2;
            usedLane = 2;
        }
        // right lane
        else if (laneSelect == 3 && rightRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], right.transform.position, right.transform.rotation);
            rightRepeats++;
            leftRepeats = 0;
            middleRepeats = 0;
            int nRight = 3;
            usedLane = 3;
        }
    }

    void SpawnPickup()
    { 
        int newlane = usedLane;
        while (newlane == usedLane)
        {
            newlane = Random.Range(1, 4);
        }

        switch (newlane)
        {
            case 1:
                GameObject newPickupLeft = Instantiate(PickUps[Random.Range(0, PickUps.Length)], left.transform.position, left.transform.rotation);
                ExistingPickups.Add(newPickupLeft);
                usedLane = newlane;
                break;
            case 2:
                GameObject newPickupMiddle = Instantiate(PickUps[Random.Range(0, PickUps.Length)], middle.transform.position, middle.transform.rotation);
                ExistingPickups.Add(newPickupMiddle);
                usedLane = newlane; 
                break;
            case 3:
                GameObject newPickupRight = Instantiate(PickUps[Random.Range(0, PickUps.Length)], right.transform.position, right.transform.rotation);
                ExistingPickups.Add(newPickupRight);
                usedLane = newlane;
                break;
            default:
                Debug.Log("PickUp Not Spawned!");
                break;
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