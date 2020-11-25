using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    [SerializeField] ScriptableInt m_scoreObject, m_comboObject;
    [SerializeField] ScriptableSoundObject m_cheeringSounds;
    [SerializeField] GameEvent m_updateScore;
    [SerializeField] ParticleSystem m_myEffect;
    public void UpdateScore(bool _isSpecial)
    {
        int _score = 1;

        _score += m_comboObject.m_Value;

        if (m_comboObject.m_Value < 10)
        {
            m_comboObject.m_Value++;
        }

        if(_isSpecial)
        {
            _score *= 2;
        }

        m_scoreObject.m_Value += _score;
        m_updateScore.Raise();
        m_myEffect.Play();
        m_cheeringSounds.Play();
    }
}
