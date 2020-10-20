using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    //all three lane transforms
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform middle;

    //individual timers for each lane to add randomness to the spawning
    private float leftTimer;
    private float rightTimer;
    private float middleTimer;

    private float leftRandomSpawnRate = Random.Range(0, 10);
    private float rightRandomSpawnRate = Random.Range(0, 10);
    private float middleRandomSpawnRate = Random.Range(0, 10);


    void FixedUpdate()
    {
        leftTimer += Time.deltaTime;
        rightTimer += Time.deltaTime;
        middleTimer += Time.deltaTime;

        if (leftTimer > leftRandomSpawnRate)
        {
            Instantiate(Obstacle, left.transform.position, new Quaternion(0,0,0,0));
        }

       
    }

    void spawnObject()
    {
       
    }
}
