using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float time = 0f;
    public float dTime = 0.1f;
    private int intLane = 0;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPos;
    public GameObject projectile;
    public GameObject FailMenu;

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
        #region MOVEMENT

        Vector3 pos = transform.position;
        // moveable == 0 means the player may move at any point 

        // on "A" or "LeftArrow" press
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (intLane != -1)
            {
                StopCoroutine(MoveDirection());
                targetPos = new Vector3(pos.x, pos.y, lanes[intLane].position.z);
                intLane--;
                time += dTime;
                StartCoroutine(MoveDirection());
            }
        }
        // on "D" or "RightArrow" press
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (intLane != 1)
            {
                StopCoroutine(MoveDirection());
                targetPos = new Vector3(pos.x, pos.y, lanes[intLane + 2].position.z);
                intLane++;
                time += dTime;
                StartCoroutine(MoveDirection());
            }
        }
        #endregion

        #region SHOOTING

        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    // move script
    IEnumerator MoveDirection()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, time);

            yield return null;
        }
        time = 0;
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FailMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
}
