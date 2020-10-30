using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilGeneration : MonoBehaviour
{
    private int spawner = 0;

    [SerializeField] GameObject DefaultSpawn;

    public int StencilsAmount = 1;
    [SerializeField] List<GameObject> Stensils = new List<GameObject>();

    private int StencilsLength = 0;
    private List<GameObject> Stencils;
    // Start is called before the first frame update
    void Start()
    {
        Stencils = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // if spawner is empty and a new stencil needs to be spawned
        if (spawner <= 0)
        {
            // if stencils is empty
            if (Stencils.Count > 0)
            {
                Vector3 newPos = Vector3.zero;

                foreach (Transform child in Stencils[Stencils.Count - 1].transform)
                {
                    if (child.name == "BACK")
                    {
                        newPos = child.position;
                        break;
                    }
                }
                StencilsLength++;

                //initialise and add new object to stencils list to track existing objects
                GameObject newStencil = Instantiate();
                newStencil.transform.position = newPos;
                Stencils.Add(newStencil);
            }
            else
            {
                Vector3 newPos = DefaultSpawn.transform.position;
                StencilsLength++;
                GameObject newStencil = Instantiate();
                newStencil.transform.position = newPos;
                Stencils.Add(newStencil);
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
