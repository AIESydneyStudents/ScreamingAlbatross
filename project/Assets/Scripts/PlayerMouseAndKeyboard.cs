﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseAndKeyboard : MonoBehaviour
{
    public bool KeyboardOrMouse = true;

    [SerializeField]
    [Range(0, 1)]
    public float mouseSensitivity;

    public float time = 0f;
    [SerializeField]
    [Range(0f, 0.2f)]
    public const float dTime = 0.1f;
    private int intLane = 0;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPos;

    public Transform leftLane;
    public Transform middleLane;
    public Transform rightLane;

    public List<Transform> lanes;

    // Start is called before the first frame update
    void Start()
    {
        lanes.Add(leftLane);
        lanes.Add(middleLane);
        lanes.Add(rightLane);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        // moveable == 0 means the player may move at any point 

        if (KeyboardOrMouse)
        {
            // on "A" or "LeftArrow" press
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (intLane != -1)
                {
                    StopCoroutine(MoveDirection(true));
                    targetPos = new Vector3(pos.x, pos.y, lanes[intLane].position.z);
                    intLane--;
                    time += dTime;
                    StartCoroutine(MoveDirection(true));
                }
                else
                {
                    Debug.Log("Illegal Move!");
                }
            }
            // on "D" or "RightArrow" press
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (intLane != 1)
                {
                    StopCoroutine(MoveDirection(false));
                    targetPos = new Vector3(pos.x, pos.y, lanes[intLane + 2].position.z);
                    intLane++;
                    time += dTime;
                    StartCoroutine(MoveDirection(false));
                }
                else
                {
                    Debug.Log("Illegal Move!");
                }
            }

        }
        // if mouse is used
        else if (!KeyboardOrMouse)
        {
            float mouseX = Input.GetAxis("Mouse X");
            pos.z += mouseX * mouseSensitivity;
            if (pos.z > 3)
            {
                pos.z = lanes[2].position.z;
                transform.position = pos;
            }
            else if (pos.z < -3)
            {
                pos.z = lanes[0].position.z;
                transform.position = pos;
            }
            else
            {
                transform.position = pos;
            }
        }
    }

    // move script
    IEnumerator MoveDirection(bool LR)
    {
        float t = 0f;
        float direction = 0;
        if (LR == true) { direction = -15; }
        else { direction = 15; }

        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            if (t < dTime / 2)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, (transform.rotation * Quaternion.AngleAxis(direction, Vector3.up)), dTime / 2);
            }
            else if (t > dTime / 2 && t < dTime)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, (transform.rotation * Quaternion.AngleAxis(-direction, Vector3.up)), dTime / 2);
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, time);

            yield return null;
        }
        time = 0;
    }

}
