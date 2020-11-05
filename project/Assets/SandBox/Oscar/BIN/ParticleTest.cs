using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticleTest : MonoBehaviour
{
    public ParticleSystem Confetti;
    public Vector3 cPos;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            Confetti.transform.position = cPos;
            Confetti.Play();
        }
    }
}
