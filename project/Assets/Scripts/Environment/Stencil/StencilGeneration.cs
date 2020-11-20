using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StencilGeneration : MonoBehaviour
{
    #region VARIABLES
    // objects in spawn count
    private int RoadSpawner = 0;
    private int ScenerySpawner = 0;

    // spawnpoints
    [SerializeField] GameObject SpawnOnStartPos;
    [SerializeField] GameObject OnStartLeftScenery;
    [SerializeField] GameObject OnStartRightScenery;

    public Transform LeftScenery;
    public Transform RightScenery;

    // gameobject lists
    [SerializeField] List<GameObject> Scenery = new List<GameObject>();
    [SerializeField] List<GameObject> Roads = new List<GameObject>();
    //bridge, 0 is MAIN 1 is base
    [SerializeField] List<GameObject> Bridge = new List<GameObject>();

    // existing GameObject lists
    private List<GameObject> GameObjectSceneryLeft;
    private List<GameObject> GameObjectSceneryRight;
    private List<GameObject> GameObjectRoads;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region LIST INITIALISE
        GameObjectSceneryLeft = new List<GameObject>();
        GameObjectSceneryRight = new List<GameObject>();
        GameObjectRoads = new List<GameObject>();
        #endregion

        #region SPAWNING FILL STENCILS ON STARTUP

        if (Roads.Count > 0)
        {
            // spawns one stencil then spawn multiple until the playing feild is full, then proceeds to fill any empty spots as the game runs
            Vector3 newPos = SpawnOnStartPos.transform.position;
            GameObject firstStencil = Instantiate(Roads[Random.Range(0, Roads.Count)]);
            firstStencil.transform.position = newPos;
            GameObjectRoads.Add(firstStencil);
        }

        // start sceneryspawn
        if (Scenery.Count > 0)
        {
            // adding scenery to left
            GameObject newSceneryLeft = Instantiate(Scenery[Random.Range(0, Scenery.Count - 1)]);
            newSceneryLeft.transform.position = OnStartLeftScenery.transform.position;
            GameObjectSceneryLeft.Add(newSceneryLeft);

            // adding scenery to right
            GameObject newSceneryRight = Instantiate(Scenery[Random.Range(0, Scenery.Count - 1)]);
            newSceneryRight.transform.position = OnStartRightScenery.transform.position;
            GameObjectSceneryRight.Add(newSceneryRight);
        }
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        #region ROAD SPAWNING
        // if spawner is empty and a new stencil needs to be spawned
        if (RoadSpawner <= 0)
        {
            // if stencils is empty
            if (GameObjectRoads.Count > 0)
            {
                Vector3 newPos = Vector3.zero;

                foreach (Transform child in GameObjectRoads[GameObjectRoads.Count - 1].transform)
                {
                    if (child.name == "BACK")
                    {
                        newPos = child.position;
                        break;
                    }
                }

                //initialise and add new object to stencils list to track existing objects
                GameObject newStencil = Instantiate(Roads[Random.Range(0, Roads.Count)], newPos, transform.rotation);
                GameObjectRoads.Add(newStencil);
            }
        }
        #endregion

        #region SCENERY SPAWNING
        if (ScenerySpawner <= 0)
        {
            Vector3 newPosLeft = Vector3.zero;
            Vector3 newPosRight = Vector3.zero;

            foreach (Transform child in GameObjectSceneryLeft[GameObjectSceneryLeft.Count - 1].transform)
            {
                if (child.name == "BACK")
                {
                    newPosLeft = child.position;
                    break;
                }
            }
            foreach (Transform child in GameObjectSceneryRight[GameObjectSceneryRight.Count - 1].transform)
            {
                if (child.name == "BACK")
                {
                    newPosRight = child.position;
                    break;
                }
            }

            // chacne to spawn a bride or nah
            int bridgeChance = Random.Range(1, 50);
            if (bridgeChance < 3)
            {
                GameObject brightMainRight = Instantiate(Bridge[0], newPosRight, transform.rotation);
                GameObjectSceneryRight.Add(brightMainRight);
                GameObject brightBaseLeft = Instantiate(Bridge[1], newPosLeft, transform.rotation);
                GameObjectSceneryLeft.Add(brightBaseLeft);
            }
            else
            {
                // adding scenery to left
                GameObject newSceneryLeft = Instantiate(Scenery[Random.Range(0, Scenery.Count)], newPosLeft, transform.rotation);
                GameObject rotateChildGroup = new GameObject();

                foreach (Transform child in newSceneryLeft.transform)
                {
                    if (child.name == "GameObject")
                    {
                        rotateChildGroup = child.gameObject;
                        break;
                    }
                }

                rotateChildGroup.transform.localRotation *= Quaternion.Euler(0, 180, 0);
                GameObjectSceneryLeft.Add(newSceneryLeft);

                // adding scenery to right
                GameObject newSceneryRight = Instantiate(Scenery[Random.Range(0, Scenery.Count)], newPosRight, transform.rotation);
                GameObjectSceneryRight.Add(newSceneryRight);
            }
        }
        #endregion
    }

    #region COLLIDERS
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            RoadSpawner--;
        }
        else if (other.gameObject.tag == "Scenery")
        {
            ScenerySpawner--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            RoadSpawner++;
        }
        else if (other.gameObject.tag == "Scenery")
        {
            ScenerySpawner++;
        }
    }
    #endregion
}
