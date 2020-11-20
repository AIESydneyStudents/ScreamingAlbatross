using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public GameObject target;
    public float m_time;
    private float m_velocity = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float targetZ = Mathf.Clamp(target.transform.position.z, -1f, 1f);
        pos.z = Mathf.SmoothDamp(pos.z, targetZ, ref m_velocity, m_time);
        transform.position = pos;
    }
}
