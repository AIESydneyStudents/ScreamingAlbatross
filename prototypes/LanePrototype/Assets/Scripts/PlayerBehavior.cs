using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private bool moveable = true;
    private int intPos = 0;
    public float speed = 3f;

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
        if (moveable)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (intPos != -1)
                {
                    Vector3 pos = transform.position;
                    transform.position = Vector3.MoveTowards(pos, new Vector3(pos.x, pos.y, lanes[intPos + 1].position.z), speed);
                }
                else
                {
                    Debug.Log("Illegal Move");
                }
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (intPos != 1)
                {
                    Vector3 pos = transform.position;
                    transform.position = Vector3.MoveTowards(pos, new Vector3(pos.x, pos.y, lanes[intPos + 3].position.z), speed);
                }
                else
                {
                    Debug.Log("Illegal Move");
                }

            }
        }
    }
}
