using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    [SerializeField]
    public ScriptableFloat speed;
  

    void Update()
    {
        transform.Translate(new Vector3(speed.m_Value, 0, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeleteBox")
        {
            Destroy(this.gameObject);
        }
    }
}
