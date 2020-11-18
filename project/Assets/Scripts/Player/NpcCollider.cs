using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollider : MonoBehaviour
{
    [SerializeField] Cannon cannonControl;
    [SerializeField] MarkerMove customerMarker;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            NPCBehaviour temp = collision.gameObject.GetComponent<NPCBehaviour>();

            if (temp.beenDelivered == false)
            {
                if (temp.hasMarker == false)
                {
                    temp.hasMarker = true;


                    MarkerMove tempMarker = Instantiate(customerMarker);
                    tempMarker.transform.position = new Vector3(collision.transform.position.x, 100, collision.transform.position.z);
                    tempMarker.gameObject.transform.parent = null;
                    
                }
                cannonControl.target = temp;
            }
        }
    }
}
