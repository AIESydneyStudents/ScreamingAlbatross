using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection = new Vector3();
    
   
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeleteBox")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
    }
    
}
