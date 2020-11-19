using System;
using UnityEngine;

public class WaveTranslation : MonoBehaviour
{
    [SerializeField] Vector3 m_direction;
    [SerializeField] float m_distance;

    float f;

    private void OnEnable()
    {
        f = 0f;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (m_direction.x * (float)(m_distance * Math.Sin(m_distance * f))), transform.position.y + (m_direction.y * (float)(m_distance * Math.Sin(m_distance * f))), transform.position.z + (m_direction.z * (float)(m_distance * Math.Sin(m_distance * f))));
        f += .01f;
    }
}
