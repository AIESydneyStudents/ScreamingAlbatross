using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject leftSpawner;
    [SerializeField] GameObject rightSpawner;

    [SerializeField] GameObject[] houses;

    [SerializeField] float spawnRate = 2;

    private float timerRight;
    private float timerLeft;

    

    void Update()
    {
        timerRight += Time.deltaTime;
        timerLeft += Time.deltaTime;

        Debug.Log(timerRight);
        Debug.Log(timerLeft);



        if (timerRight > spawnRate)
        {
            Instantiate(houses[Random.Range(0, houses.Length)], rightSpawner.transform);
            timerRight = 0;
        }
        if (timerLeft > spawnRate)
        {
            Instantiate(houses[Random.Range(0, houses.Length)], leftSpawner.transform.position,);
            timerLeft = 0;
        }
        
    }
}
