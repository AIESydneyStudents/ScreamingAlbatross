using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMove : MonoBehaviour
{
    public NPCBehaviour customer;
    public float height;
    [SerializeField] ScriptableFloat speed;
    public float fallSpeed;
    public float spinSpeed;
    private float flyDelay = 1;
    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (customer.projectileCollided == false)
        {

            if (transform.position.y > customer.gameObject.transform.position.y + 25)
                transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);

            else if (transform.position.y > customer.gameObject.transform.position.y + 15)
                transform.position = new Vector3(transform.position.x, (transform.position.y - fallSpeed * Time.deltaTime * 0.2f), transform.position.z);

            else if (transform.position.y > customer.gameObject.transform.position.y + 10)
                transform.position = new Vector3(transform.position.x, (transform.position.y - fallSpeed * Time.deltaTime * 0.1f), transform.position.z);

            else if (transform.position.y > customer.gameObject.transform.position.y + height)
                transform.position = new Vector3(transform.position.x, (transform.position.y - fallSpeed * Time.deltaTime * 0.05f), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + fallSpeed * Time.deltaTime, transform.position.z);
            Destroy(this, 2.0f);
        }

        transform.position = new Vector3(transform.position.x + speed.m_Value * Time.deltaTime, transform.position.y, transform.position.z);

        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeleteBox")
            Destroy(this.gameObject);
    }
}
