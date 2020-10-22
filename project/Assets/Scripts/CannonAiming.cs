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
    //private void OnCollisionExit(Collision collision)
    //{
    //    cannonControl.target = null;
    //    cannonControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    //}

}
