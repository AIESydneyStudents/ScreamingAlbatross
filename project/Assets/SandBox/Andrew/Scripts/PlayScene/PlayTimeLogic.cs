using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayTimeLogic : MonoBehaviour
{
    [SerializeField] Text m_text;
    private float m_elapsedTime;
    private void OnEnable()
    {
        m_elapsedTime = 0f;
        UpdateTime();
    }
    private void FixedUpdate()
    {
        m_elapsedTime += Time.fixedDeltaTime;
        UpdateTime();
    }

    private void UpdateTime()
    {
        m_text.text = (/*mins*/ ((int)(m_elapsedTime / 60f)).ToString("D2") + ":" /*secs*/ + ((int)m_elapsedTime).ToString("D2"));
    }
}