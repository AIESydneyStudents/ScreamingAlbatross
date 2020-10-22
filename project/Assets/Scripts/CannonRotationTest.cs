using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationTest : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Rotate(0, 90, 0);
        }
    }
}
