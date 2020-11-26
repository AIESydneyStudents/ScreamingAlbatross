using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySpeed : MonoBehaviour
{
    // setting tick timer and timer initialisation
    private float speedTimer = 0.2f;
    private float timer;
    // speed increase per allocated tick
    private float speedIncrease = 0.07f;
    // scriptable float linking to the global speed float
    public ScriptableFloat speed;

    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        speed.m_Value = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;

            if (timer >= speedTimer)
            {
                speed.m_Value += speedIncrease;
                timer = 0;
            }
            if (speed.m_Value > 80f)
            {
                isRunning = false;
            }
        }

    }
}
