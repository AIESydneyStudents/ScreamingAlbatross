using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefab;
    [SerializeField] GameObject leftSidewalk;
    [SerializeField] GameObject rightSidewalk;


    private float spawnTimer = 0;
    public float spawnRate = 1;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            if (Random.Range(0, 2) >= 1)
                Instantiate(customerPrefab[Random.Range(0, customerPrefab.Length)], leftSidewalk.transform);
            else
                Instantiate(customerPrefab[Random.Range(0, customerPrefab.Length)], rightSidewalk.transform);

            spawnTimer = 0;
        }
    }
}
