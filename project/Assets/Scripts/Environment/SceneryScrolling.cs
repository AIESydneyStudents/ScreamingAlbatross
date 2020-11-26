using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float xOffset = 0;
    [SerializeField] ScriptableFloat m_gameSpeed;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        xOffset += scrollSpeed * m_gameSpeed.m_Value * Time.deltaTime;
        mat.SetFloat("MyXOffset", xOffset);
    }
}
