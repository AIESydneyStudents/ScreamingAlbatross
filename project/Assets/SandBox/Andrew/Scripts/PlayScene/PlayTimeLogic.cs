using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayTimeLogic : MonoBehaviour
{
    [SerializeField] Text m_text;
    private float m_elapsedTime;
    private int m_elapsedMins;
    private void OnEnable()
    {
        m_elapsedTime = 0f;
        m_elapsedMins = 0;
        UpdateTime();
    }
    private void FixedUpdate()
    {
        m_elapsedTime += Time.fixedDeltaTime;
        UpdateTime();
    }

    private void UpdateTime()
    {
        if(m_elapsedTime >= 60f)
        {
            m_elapsedTime -= 60f;
            m_elapsedMins++;
        }
        m_text.text = (/*mins*/ m_elapsedMins.ToString("D2") + ":" /*secs*/ + ((int)m_elapsedTime).ToString("D2"));
    }
}