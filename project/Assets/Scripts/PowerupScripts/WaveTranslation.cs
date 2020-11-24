using System;
using UnityEngine;

public class WaveTranslation : MonoBehaviour
{
    [SerializeField] Vector3 m_direction;
    [SerializeField] float m_distance;

    float y;
    public float speed = 0.5f;

    private void OnEnable()
    {
        y = 0f;
    }
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = 0.6f * Mathf.Sin(y) + 2;
        //transform.position = new Vector3(transform.position.x + (m_direction.x * (float)(m_distance * Math.Sin(m_distance * f))), transform.position.y + (m_direction.y * (float)(m_distance * Math.Sin(m_distance * f))), transform.position.z + (m_direction.z * (float)(m_distance * Math.Sin(m_distance * f))));
        transform.position = pos;
        y += speed;
    }
}
