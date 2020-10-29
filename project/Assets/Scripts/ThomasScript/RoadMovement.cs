using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float m_moveSpeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(m_moveSpeed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.position = spawner.transform.position;
    }
}
