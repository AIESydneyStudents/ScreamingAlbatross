using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    [SerializeField] ScriptableInt m_scoreObject, m_comboObject;
    [SerializeField] ScriptableSoundObject m_cheeringSounds;
    [SerializeField] bool m_IsSpecial;
    
    public void Initialize(bool b)
    {
        m_IsSpecial = b;
    }

    public void PlaySound()
    {
        m_cheeringSounds.Play();
    }

    public void UpdateScore()
    {
        int _score = 1;

        _score += m_comboObject.m_Value;

        if(m_IsSpecial)
        {
            _score *= 2;
        }

        m_scoreObject.m_Value += _score;
    }
}