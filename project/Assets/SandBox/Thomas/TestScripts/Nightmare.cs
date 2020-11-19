using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    [SerializeField] GameObject Frank;
    private bool frankSpawned = false;
    private GameObject frank;
    void Update()
    {
        if (frankSpawned == false)
        {
            if (Input.GetKeyDown(KeyCode.L) == true && Input.GetKeyDown(KeyCode.Alpha5) == true && Input.GetKeyDown(KeyCode.V) == true && Input.GetKeyDown(KeyCode.M) == true)
            {
                frank = Instantiate(Frank, transform);
                frankSpawned = true;
            }
        }
        

    }
}
