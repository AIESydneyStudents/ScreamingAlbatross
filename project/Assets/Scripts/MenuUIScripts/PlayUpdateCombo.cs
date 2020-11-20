using UnityEngine;
using UnityEngine.UI;

public class PlayUpdateCombo : MonoBehaviour
{
    [SerializeField] ScriptableInt m_comboObject;
    [SerializeField] Text m_text;

    public void UpdateCombo()
    {
        m_text.text =  "1 + " + m_comboObject.m_Value.ToString();
    }
}