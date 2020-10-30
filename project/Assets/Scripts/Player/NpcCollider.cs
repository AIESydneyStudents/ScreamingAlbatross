using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollider : MonoBehaviour
{
    [SerializeField] Cannon cannonControl;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            cannonControl.target = collision.gameObject;
            cannonControl.newCustomer = true;
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
