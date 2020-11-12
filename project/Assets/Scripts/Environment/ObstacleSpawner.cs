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
            if (laneSelect < 50 && leftRepeats < repeatAllowed && leftUsed == false)
            {
                leftUsed = true;
                GameObject temp = Instantiate(ObstaclePrefab, left.transform);
                temp.tag = "Left";
                leftRepeats++;
                rightRepeats = 0;
                middleRepeats = 0;
            }
            if (laneSelect >= 50 && laneSelect < 100 && middleRepeats < repeatAllowed && middleUsed == false)
            {
                middleUsed = true;
                GameObject temp = Instantiate(ObstaclePrefab, middle.transform);
                temp.tag = "Middle";
                middleRepeats++;
                leftRepeats = 0;
                rightRepeats = 0;
            }
            if (laneSelect >= 100 && rightRepeats < repeatAllowed && rightUsed == false)
            {
                rightUsed = true;
                GameObject temp = Instantiate(ObstaclePrefab, right.transform);
                temp.tag = "Right";
                rightRepeats++;
                leftRepeats = 0;
                middleRepeats = 0;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Help");
        if (other.tag == "Left")
        {
            Debug.Log("Left");
            leftUsed = false;
            other.tag = "Obstacle";
        }
        if (other.tag == "Middle")
        {
            Debug.Log("Middle");
            middleUsed = false;
            other.tag = "Obstacle";
        }
        if (other.tag == "Right")
        {
            Debug.Log("Right");
            rightUsed = false;
            other.tag = "Obstacle";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Help");
    }

}
