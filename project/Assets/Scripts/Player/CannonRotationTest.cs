using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationTest : MonoBehaviour
{
    private float speed = 2f;
    public GameObject target;
    private Quaternion normalDirection;
    private ProjectileMovement projectilTarget;

    private void Start()
    {
        normalDirection = transform.rotation;
    }

    void Update()
    {
        if (target != null)
        {
            speed = 10;
            Vector3 dirToTarget = target.transform.position - transform.position;
            dirToTarget.y = 0f;

            Quaternion lookAt = Quaternion.LookRotation(dirToTarget);
            lookAt.eulerAngles += new Vector3(0, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * speed);
        }
        else
        {
            speed = 2;
            Quaternion lookAt = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * speed);
        }
    }
}
