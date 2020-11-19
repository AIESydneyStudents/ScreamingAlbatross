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
    private List<int> usedLanes = new List<int>();

    private bool start = true;

    void Update()
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
        // left lane
        laneSelect = Random.Range(1, 4);
        if (laneSelect == 1 && leftRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], left.transform.position, left.transform.rotation);
            leftRepeats++;
            rightRepeats = 0;
            middleRepeats = 0;
            int nLeft = 1;
            usedLanes.Add(nLeft);
        }
        // middle lane
        else if (laneSelect == 2 && middleRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], middle.transform.position, middle.transform.rotation);
            middleRepeats++;
            leftRepeats = 0;
            rightRepeats = 0;
            int nMiddle = 2;
            usedLanes.Add(nMiddle);
        }
        // right lane
        else if (laneSelect == 3 && rightRepeats <= repeatAllowed)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Length - 1)], right.transform.position, right.transform.rotation);
            rightRepeats++;
            leftRepeats = 0;
            middleRepeats = 0;
            int nRight = 3;
            usedLanes.Add(nRight);
        }
    }

    void SpawnPickup()
    {
        Debug.Log(usedLanes.Count);
        int usedlane = usedLanes[usedLanes.Count - 1];
        int newlane = usedlane;
        while (newlane == usedlane)
        {
            newlane = Random.Range(1, 4);
        }

        switch (newlane)
        {
            case 1:
                GameObject newPickupLeft = Instantiate(PickUps[Random.Range(0, PickUps.Length - 1)], left.transform.position, left.transform.rotation);
                ExistingPickups.Add(newPickupLeft);
                break;
            case 2:
                GameObject newPickupMiddle = Instantiate(PickUps[Random.Range(0, PickUps.Length - 1)], middle.transform.position, middle.transform.rotation);
                ExistingPickups.Add(newPickupMiddle);
                break;
            case 3:
                GameObject newPickupRight = Instantiate(PickUps[Random.Range(0, PickUps.Length - 1)], right.transform.position, right.transform.rotation);
                ExistingPickups.Add(newPickupRight);
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