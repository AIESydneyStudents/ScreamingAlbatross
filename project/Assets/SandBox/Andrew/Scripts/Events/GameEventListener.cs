using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    public GameEvent[] m_Event;
    public UnityEvent m_Response;
    private void OnEnable()
    {
        for (int i = 0; i < m_Event.Length; i++)
            m_Event[i].RegisterListener(this);
    }
    private void OnDisable()
    {
        for (int i = 0; i < m_Event.Length; i++)
            m_Event[i].UnregisterListener(this);
    }
    public void OnEventRaised() => m_Response.Invoke();
}
