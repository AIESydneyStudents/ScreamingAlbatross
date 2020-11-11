using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float time = 0f;
    public float dTime = 0.1f;
    private int intLane = 0;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPos;
    public GameObject FailMenu;

    private int score;
    public int teaAmount;
    [SerializeField] GameObject scoreUI;
    Text scoreText;
    [SerializeField] GameObject timeUI;
    Text timeText;
    [SerializeField] GameObject teaDeliveredUI;
    Text teaAmountText;
    [SerializeField] GameObject totalScoreUI;
    Text totalScoreText;

    [SerializeField] GameObject inGameScoreUI;
    Text inGameScoreText;

    private float totalRunTime = 0;

    public Transform CustomerCollider;

    public Transform leftLane;
    public Transform middleLane;
    public Transform rightLane;

    public List<Transform> lanes;

    int scoreTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
        teaAmountText = teaDeliveredUI.GetComponent<Text>();
        totalScoreText = totalScoreUI.GetComponent<Text>();
        inGameScoreText = inGameScoreUI.GetComponent<Text>();



        lanes.Add(leftLane);
        lanes.Add(middleLane);
        lanes.Add(rightLane);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTimer++;
        if (scoreTimer > 3)
        {
            if (FailMenu.activeInHierarchy == false)
            {

                score++;
                scoreTimer = 0;
                inGameScoreText.text = "Score: " + score;
            }
        }
        totalRunTime += Time.deltaTime;
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
        #endregion
    }

    // move script
    IEnumerator MoveDirection()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, time);
            CustomerCollider.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, time);
            yield return null;
        }
        time = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            LoadFail();
        }
    }
    private void LoadFail()
    {
        FailMenu.SetActive(true);
        Time.timeScale = 0.0f;

        timeText.text = "Time: " + (int)totalRunTime;
        scoreText.text = "Score: " + score;
        teaAmountText.text = "Tea Delivered: " + teaAmount;

        int totalScore = (int)totalRunTime + score + (teaAmount * 3);
        totalScoreText.text = "Total Score: " + totalScore;
    }
}
