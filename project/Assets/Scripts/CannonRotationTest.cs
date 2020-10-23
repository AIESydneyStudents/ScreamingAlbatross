using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationTest : MonoBehaviour
{
    public GameObject target;
    [SerializeField] GameObject projectile;
    private GameObject recentShot;
    public int amountOfTeaDelivered;
    
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, transform.rotation);
            amountOfTeaDelivered++;
        }
    }

}
