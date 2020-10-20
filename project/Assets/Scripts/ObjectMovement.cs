using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    public float speed = 5;

    public GameObject m_spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathCollider")
        {
            Vector3 pos = m_spawner.gameObject.transform.position;
            float iterator = Random.Range(-1, 1);
            pos.z += iterator;
            transform.position = pos;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }
}
