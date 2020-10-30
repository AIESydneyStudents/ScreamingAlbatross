using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilGeneration : MonoBehaviour
{
    private int spawner = 0;

    [SerializeField] GameObject DefaultSpawn;

    [SerializeField] GameObject Stencil1;
    [SerializeField] GameObject Stencil2;

    private int StencilsLength = 0;
    List<GameObject> Stencils;
    // Start is called before the first frame update
    void Start()
    {

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

                foreach (Transform child in Stencils[StencilsLength - 1].transform)
                {
                    if (child.name == "BACK")
                    {
                        newPos = child.position;
                        break;
                    }
                }
                // error tracing
                if (newPos == Vector3.zero)
                { Debug.Log("No Existing Stencils!"); }

                StencilsLength++;

                //initialise and add new object to stencils list to track existing objects
                GameObject newStencil = Instantiate(Stencil1);
                newStencil.transform.position = newPos;
                Stencils.Add(newStencil);
            }
            else
            {
                Vector3 newPos = DefaultSpawn.transform.position;
                StencilsLength++;
                GameObject newStencil = Instantiate(Stencil2);
                newStencil.transform.position = newPos;
                Stencils.Add(newStencil);
            }
        }
    }


}
