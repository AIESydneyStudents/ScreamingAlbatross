using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float scale;
    [SerializeField] float shootSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 90, 0);
        transform.position += transform.forward * -scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.forward * shootSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Customer")
        {
            Destroy(transform.gameObject);

        }
    }
}
