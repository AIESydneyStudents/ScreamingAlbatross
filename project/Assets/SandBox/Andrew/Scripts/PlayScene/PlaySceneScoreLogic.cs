using System;
using UnityEngine;
using UnityEngine.UI;
public class PlaySceneScoreLogic : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] ScriptableFloat m_scoreVariable;

    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        m_text.text = "Score: " + m_scoreVariable.m_Value.ToString();
    }
}
