using UnityEngine;
using UnityEngine.UI;

public class TeaBagPrefabLogic : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] ScriptableFloat m_myCount;

    private void OnEnable()
    {
        UpdateCount();
    }

    public void UpdateCount()
    {
        m_text.text = ((int)m_myCount.m_Value).ToString();
    }
}
