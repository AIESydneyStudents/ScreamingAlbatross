using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementRoad : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    public float speed = 5;

    public GameObject m_spawner;
    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathCollider")
        {
            transform.position = m_spawner.gameObject.transform.position;
        }
        if (other.gameObject.tag == "DeleteBox")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeleteBox")
        {
            Destroy(this.gameObject);
        }
    }
}
