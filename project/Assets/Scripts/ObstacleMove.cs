using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    public float speed = 5;

    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeleteBox")
        {
            Destroy(this.gameObject);
        }
    }
}
