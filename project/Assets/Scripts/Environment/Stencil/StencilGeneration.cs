using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StencilGeneration : MonoBehaviour
{
    // objects in spawn count
    private int RoadSpawner = 0;
    private int ScenerySpawner = 0;

    // spawnpoints
    [SerializeField] GameObject SpawnOnStartPos;
    [SerializeField] GameObject DefaultSpawn;
    public Transform LeftScenery;
    public Transform RightScenery;

    // gameobject lists
    [SerializeField] List<GameObject> Scenery = new List<GameObject>();
    [SerializeField] List<GameObject> Roads = new List<GameObject>();

    // 
    private List<GameObject> GameObjectStencils;


    // Start is called before the first frame update
    void Start()
    {
        GameObjectStencils = new List<GameObject>();


        #region SPAWNING FILL STENCILS ON STARTUP

        // spawns one stencil then spawn multiple until the playing feild is full, then proceeds to fill any empty spots as the game runs

        Vector3 newPos = SpawnOnStartPos.transform.position;
        GameObject firstStencil = Instantiate(Roads[Random.Range(0, Roads.Count)]);
        firstStencil.transform.position = newPos;
        GameObjectStencils.Add(firstStencil);

        StartCoroutine("OnStart");
    }

    private IEnumerator OnStart()
    {
        while (RoadSpawner <= 0)
        {
            Vector3 newPos = Vector3.zero;

            foreach (Transform child in GameObjectStencils[GameObjectStencils.Count - 1].transform)
            {
                if (child.name == "BACK")
                {
                    newPos = child.position;
                    break;
                }
            }

            // initialise and add new object to stencils list to track existing objects
            GameObject newStencil = Instantiate(Roads[Random.Range(0, Roads.Count)]);
            newStencil.transform.position = newPos;
            GameObjectStencils.Add(newStencil);

            yield return null;
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        // if spawner is empty and a new stencil needs to be spawned
        if (RoadSpawner <= 0)
        {
            // if stencils is empty
            if (GameObjectStencils.Count > 0)
            {
                Vector3 newPos = Vector3.zero;

                foreach (Transform child in GameObjectStencils[GameObjectStencils.Count - 1].transform)
                {
                    if (child.name == "BACK")
                    {
                        newPos = child.position;
                        break;
                    }
                }

                //initialise and add new object to stencils list to track existing objects
                GameObject newStencil = Instantiate(Roads[Random.Range(0, Roads.Count - 1)]);
                newStencil.transform.position = newPos;
                GameObjectStencils.Add(newStencil);
            }
            else
            {
                Vector3 newPos = DefaultSpawn.transform.position;
                GameObject newStencil = Instantiate(Roads[Random.Range(0, Roads.Count - 1)]);
                newStencil.transform.position = newPos;
                GameObjectStencils.Add(newStencil);
            }
        }

        // 
        GameObject newSceneryLeft = Instantiate(Scenery[Random.Range(0, Scenery.Count - 1)]);
        newSceneryLeft.transform.position = LeftScenery.position;

        GameObject newSceneryRight = Instantiate(Scenery[Random.Range(0, Scenery.Count - 1)]);
        newSceneryRight.transform.position = LeftScenery.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            RoadSpawner--;
        }
        else if (other.gameObject.tag == "Scenery")
        {
            RoadSpawner--;
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
            RoadSpawner++;
        }
    }
}
