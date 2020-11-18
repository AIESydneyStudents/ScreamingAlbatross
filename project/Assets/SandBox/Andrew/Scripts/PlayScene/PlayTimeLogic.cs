using UnityEngine;
using UnityEngine.UI;
public class PlayTimeLogic : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] ScriptableFloat m_timeVariable;
    private void OnEnable()
    {
        m_timeVariable.m_Value = 0f;
        UpdateTime();
    }
    private void FixedUpdate()
    {
        m_timeVariable.m_Value += Time.fixedDeltaTime;
        UpdateTime();
    }

    private void UpdateTime()
    {
        int mins = (int)(m_timeVariable.m_Value / 60f);
        int secs = (int)m_timeVariable.m_Value - (mins * 60);
        m_text.text = (/*mins*/ mins.ToString("D2") + ":" /*secs*/ + secs.ToString("D2"));
    }
}