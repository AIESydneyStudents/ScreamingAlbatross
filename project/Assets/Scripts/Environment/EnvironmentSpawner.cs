using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject leftSpawner;
    [SerializeField] GameObject rightSpawner;

    [SerializeField] GameObject[] houses;

    [SerializeField] float spawnRate = 2;

    [SerializeField] float rotateLeft = 0;
    [SerializeField] float rotateRight = 0;

    private float timerRight;
    private float timerLeft;

    

    void FixedUpdate()
    {
        timerRight += Time.deltaTime;
        timerLeft += Time.deltaTime;

        



        if (timerRight > spawnRate)
        {
            GameObject temp = Instantiate(houses[Random.Range(0, houses.Length)], rightSpawner.transform);
            temp.transform.Rotate(0, rotateRight, 0);
            timerRight = 0;
        }
        if (timerLeft > spawnRate)
        {
            GameObject temp = Instantiate(houses[Random.Range(0, houses.Length)], leftSpawner.transform);
            temp.transform.Rotate(0, rotateLeft, 0);
            timerLeft = 0;
        }
        
    }
}
