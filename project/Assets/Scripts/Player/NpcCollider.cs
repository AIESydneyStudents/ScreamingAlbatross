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
            NPCBehaviour temp = collision.gameObject.GetComponent<NPCBehaviour>();
            if (temp.beenDelivered == false)
            {
                cannonControl.target = collision.gameObject.GetComponent<NPCBehaviour>();
            }

        }
    }
    
    

}
