using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float scale;
    public float shootSpeed;
    public GameObject projectileTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 90, 0);
        transform.position += transform.forward * -scale;
        Destroy(this, 10.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(projectileTarget.transform);
        transform.position += transform.forward * shootSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 3f, 90), transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Customer")
        {
            Destroy(this.gameObject);
        }
    }
}
