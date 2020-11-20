using UnityEngine;
using UnityEngine.UI;

public class PlayUpdateScore : MonoBehaviour
{
    [SerializeField] ScriptableInt m_scoreObject;
    [SerializeField] Text m_text;

    public void UpdateScore()
    {
        m_text.text = m_scoreObject.m_Value.ToString();
    }
}
