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

    //event to call the player has collided
    [SerializeField] GameEvent m_gameOver, m_pickupEvent;

    /*public GameObject FailMenu;

    private int score;*/
    public int teaAmount;
    /*[SerializeField] GameObject scoreUI;
    Text scoreText;
    [SerializeField] GameObject timeUI;
    Text timeText;
    [SerializeField] GameObject teaDeliveredUI;
    Text teaAmountText;
    [SerializeField] GameObject totalScoreUI;
    Text totalScoreText;

    [SerializeField] GameObject inGameScoreUI;
    Text inGameScoreText;*/

    private float totalRunTime = 0;

    public Transform CustomerCollider;

    public Transform leftLane;
    public Transform middleLane;
    public Transform rightLane;

    public List<Transform> lanes;

    private bool movingLeft = false;
    private bool movingRight = false;

    //the move function thing is too slow as it approaches the lane so the delay for the animations has to be seperate 
    //so its not moving with weird delays
    private float animationTimer = 0;
    [SerializeField] float animationDelay = 0.2f;
    
    public float turningSpeed = 2;

    //add spaces in inspector

    [SerializeField] ScriptableSoundObject m_Horn;
    [SerializeField] ScriptableSoundObject m_Pickup;
    [SerializeField] ScriptableSoundObject m_TireScreech;
    [SerializeField] ScriptableSoundObject m_Crash;

    [SerializeField] ScriptableFloat a_BritishTeaCount;
    [SerializeField] ScriptableFloat a_ChineseTeaCount;
    [SerializeField] ScriptableFloat a_IndianTeaCount;

    public Animation turningAnimations;

    int scoreTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
        teaAmountText = teaDeliveredUI.GetComponent<Text>();
        totalScoreText = totalScoreUI.GetComponent<Text>();
        inGameScoreText = inGameScoreUI.GetComponent<Text>();*/

        lanes.Add(leftLane);
        lanes.Add(middleLane);
        lanes.Add(rightLane);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft || movingRight)
        {
            animationTimer += Time.deltaTime;
            if (movingLeft && animationTimer >= animationDelay)
            {
                turningAnimations.Play("LeftTurnFinish");
                movingLeft = false;
                animationTimer = 0;
            }
            if (movingRight && animationTimer >= animationDelay)
            {
                turningAnimations.Play("RightTurnFinish");
                movingRight = false;
                animationTimer = 0;
            }
        }
        /*scoreTimer++;
        if (scoreTimer > 3)
        {
            if (FailMenu.activeInHierarchy == false)
            {

                score++;
                scoreTimer = 0;
                inGameScoreText.text = "Score: " + score;
            }
        }
        totalRunTime += Time.deltaTime;*/
        #region MOVEMENT

        Vector3 pos = transform.position;
        // on "A" or "LeftArrow" press
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TireScreechSound();

            if (intLane != -1)
            {
                //this is to stop the overlap of animations if already moving to the left
                if (movingLeft == false)
                {
                    turningAnimations.Play("TurnLeftOnly");
                }
                movingLeft = true;
                movingRight = false;
                
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
            TireScreechSound();

            if (intLane != 1)
            {
                if (movingRight == false)
                {
                    turningAnimations.Play("TurnRightOnly");
                }
                movingRight = true;
                movingLeft = false;
                StopCoroutine(MoveDirection());
                targetPos = new Vector3(pos.x, pos.y, lanes[intLane + 2].position.z);
                intLane++;
                time += dTime;
                StartCoroutine(MoveDirection());
            }
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

    void TireScreechSound()
    {
        int soundChance = Random.Range(1, 5);
        if (soundChance == 1)
        {
            m_TireScreech.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            m_Crash.Play();
            m_gameOver.Raise();
            LoadFail();
        }

        //if (other.tag == "Pickup")
        //{
        //    m_Pickup.Play();
        //    switch (other.GetComponent<PickupLogic>().m_Theme)
        //    {
        //        case Themes.British:
        //            a_BritishTeaCount.m_Value++;
        //            break;
        //        case Themes.Chinese:
        //            a_ChineseTeaCount.m_Value++;
        //            break;
        //        case Themes.Indian:
        //            a_IndianTeaCount.m_Value++;
        //            break;
        //    }
        //    Destroy(other.gameObject);
        //    m_pickupEvent.Raise();
        //}

        if (other.gameObject.tag == "British")
        {
            a_BritishTeaCount.m_Value++;
            PickUp(other);
        }
        if (other.gameObject.tag == "Chinese")
        {
            a_ChineseTeaCount.m_Value++;
            PickUp(other);
        }
        if (other.gameObject.tag == "Indian")
        {
            a_IndianTeaCount.m_Value++;
            PickUp(other);
        }
    }
    
    private void PickUp(Collider other)
    {
        m_Pickup.Play();
        Destroy(other.gameObject);
        m_pickupEvent.Raise();
    }


    private void LoadFail()
    {
        /*FailMenu.SetActive(true);
        Time.timeScale = 0.0f;

        timeText.text = "Time: " + (int)totalRunTime;
        scoreText.text = "Score: " + score;
        teaAmountText.text = "Tea Delivered: " + teaAmount;

        int totalScore = (int)totalRunTime + score + (teaAmount * 3);
        totalScoreText.text = "Total Score: " + totalScore;*/
    }
}
