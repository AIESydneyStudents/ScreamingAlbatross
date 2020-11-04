using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    //widths are standard from using progrids to scale to a certain width 

    //using oscars spawner to get when to delete or spawn a new object set

    //road and house prefabs to a set length so only one spawn is needed for the 
    //left and right and road at once

    [SerializeField] float roadWidth = 25;
    [SerializeField] float sideWalkWidth = 3;
    [SerializeField] float houseWidth = 10;

    //change back to a array later
    [SerializeField] GameObject[] roadPrefabs;

    [SerializeField] GameObject[] housePrefabs;
    [SerializeField] GameObject sideWalkPrefab;

    //keeps track of how many lanes there are 
    public int roadCountRight;
    public int roadCountLeft;

    //have other functions when creating new roads to decide on to add to the left or right of the lane currently 
    //so its not all on the one side being added and subtracted

    //length of road, sidewalk, general prefabs of houses
    //spawner at 0,0,0 and go off that in the - and + sides

    bool addedLeftLane = false;
    bool addedRightLane = false;
    bool spawnCrossLeft = false;
    bool spawnCrossRight = false;

    private Rigidbody rb;
    private float timer;
    public float spawnTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        #region Spawning
        
        //DEBUGGING ONLY
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            roadCountLeft++;
            addedLeftLane = true;
            spawnCrossLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            roadCountRight++;
            addedRightLane = true;
            spawnCrossRight = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (roadCountLeft > 0)
                roadCountLeft--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (roadCountRight > 0)
                roadCountRight--;
        }
        //END DEBUGGING

        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            timer = 0.0f;

            //spawnRight
            if (roadCountRight >= 1)
            {
                for (int i = 0; i <= roadCountRight; ++i)
                {
                    if (addedRightLane == true && i == roadCountRight)
                    {
                        addedRightLane = false;
                        break;
                    }
                    if (roadCountRight == 1 && addedRightLane)
                    {
                        addedRightLane = false;
                        break;
                    }
                    if (spawnCrossRight == false)
                    {
                        GameObject temp = Instantiate(roadPrefabs[0], transform);
                        if (i == 0)
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + roadWidth);
                        else
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (roadWidth * i));
                    }
                    else
                    {
                        spawnCrossRight = false;
                        GameObject temp = Instantiate(roadPrefabs[1], transform);
                        if (i == 0)
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + roadWidth);
                        else
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (roadWidth * i));
                        break;
                    }
                }
            }
            //spawnLeft
            if (roadCountLeft >= 1)
            {

                for (int i = 0; i <= roadCountLeft; ++i)
                {
                    if (addedLeftLane == true && i == roadCountLeft)
                    {
                        addedLeftLane = false;
                        break;
                    }
                    if (roadCountLeft == 1 && addedLeftLane)
                    {
                        addedLeftLane = false;
                        break;
                    }
                    if (spawnCrossLeft == false)
                    {
                        GameObject temp = Instantiate(roadPrefabs[0], transform);
                        if (i == 0)
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roadWidth);
                        else
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (roadWidth * i));
                    }
                    else
                    {
                        spawnCrossLeft = false;
                        GameObject temp = Instantiate(roadPrefabs[1], transform);
                        if (i == 0)
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roadWidth);
                        else
                            temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (roadWidth * i));
                        break;
                    }
                }
            }



            //spawn House;
            GameObject tempHouseLeft = Instantiate(housePrefabs[Random.Range(0, housePrefabs.Length)], transform);
            if (roadCountLeft == 0)
                tempHouseLeft.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roadWidth);
            else
                tempHouseLeft.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roadWidth - (roadWidth * roadCountLeft));

            GameObject tempHouseRight = Instantiate(housePrefabs[Random.Range(0, housePrefabs.Length)], transform);
            if (roadCountRight == 0)
                tempHouseRight.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + roadWidth);
            else
                tempHouseRight.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + roadWidth + (roadWidth * roadCountRight));
        }
    
    #endregion

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            Instantiate(housePrefabs[0], transform);
        }
    }

}
