using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilGeneration : MonoBehaviour
{
    private int spawner = 0;

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
        if (spawner <= 0)
        {
            if (Stencils.Count > 0)
            {
                StencilsLength++;
                GameObject newStencil = Instantiate(Stencils[StencilsLength]);
            }
            else
            {
                StencilsLength++;
            }
        }
    }


}
