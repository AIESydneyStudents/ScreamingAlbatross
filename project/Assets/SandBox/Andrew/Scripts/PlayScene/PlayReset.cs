using UnityEngine;

public class PlayReset : MonoBehaviour
{
    [SerializeField] ScriptableFloat[] m_resetFloats;
    [SerializeField] ScriptableInt[] m_resetInts;
    [SerializeField] GameEvent[] m_events;
    private void OnEnable()
    {
        foreach (ScriptableInt i in m_resetInts)
        {
            i.Reset();
        }

        foreach (ScriptableFloat f in m_resetFloats)
        {
            f.Reset();
        }
    }

    private void Start()
    {
        foreach (GameEvent e in m_events)
        {
            e.Raise();
        }
    }
}