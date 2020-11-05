using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StencilGeneration : MonoBehaviour
{
    // objects in spawn count
    private int spawner = 0;
    
    // spawnpoints
    [SerializeField] GameObject SpawnOnStartPos;
    [SerializeField] GameObject DefaultSpawn;
    public Position Left;
    public Position Right;

    // gameobject lists
    [SerializeField] List<GameObject> Stencils = new List<GameObject>();
    [SerializeField] List<GameObject> Environments = new List<GameObject>();
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
        GameObject firstStencil = Instantiate(Stencils[Random.Range(0, Stencils.Count)]);
        firstStencil.transform.position = newPos;
        GameObjectStencils.Add(firstStencil);

        StartCoroutine("OnStart");
    }

    private IEnumerator OnStart()
    {
        while (spawner <= 0)
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
            GameObject newStencil = Instantiate(Stencils[Random.Range(0, Stencils.Count)]);
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
        if (spawner <= 0)
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
                GameObject newStencil = Instantiate(Stencils[Random.Range(0, Stencils.Count)]);
                newStencil.transform.position = newPos;
                GameObjectStencils.Add(newStencil);
            }
            else
            {
                Vector3 newPos = DefaultSpawn.transform.position;
                GameObject newStencil = Instantiate(Stencils[Random.Range(0, Stencils.Count)]);
                newStencil.transform.position = newPos;
                GameObjectStencils.Add(newStencil);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stencil")
        {
            spawner--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stencil")
        {
            spawner++;
        }
    }
}
