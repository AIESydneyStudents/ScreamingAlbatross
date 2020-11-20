using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public GameObject target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = Mathf.Lerp(pos.z, Mathf.Clamp(target.transform.position.z, -3, 3), speed);
        transform.position = pos;
    }
}
