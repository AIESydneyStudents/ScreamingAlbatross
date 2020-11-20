using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    [SerializeField] ScriptableFloat Speed;
    public float mod;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1), Speed.m_Value * mod);
    }
}
