using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMove : MonoBehaviour
{
    public float height;
    [SerializeField] ScriptableFloat speed;
    public float fallSpeed;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > height)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x + speed.m_Value * Time.deltaTime, transform.position.y, transform.position.z);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeleteBox")
            Destroy(this.gameObject);
    }
}
