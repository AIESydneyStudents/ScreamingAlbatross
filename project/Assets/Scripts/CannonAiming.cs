using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAiming : MonoBehaviour
{
    [SerializeField] CannonRotationTest cannonControl;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            cannonControl.target = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            cannonControl.target = null;
        }
    }

}
