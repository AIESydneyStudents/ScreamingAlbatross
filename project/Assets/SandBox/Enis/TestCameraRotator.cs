using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraRotator : MonoBehaviour
{
    [SerializeField] float m_rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * m_rotateSpeed * Time.deltaTime);
    }
}
