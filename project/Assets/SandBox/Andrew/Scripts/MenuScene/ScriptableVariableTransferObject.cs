using UnityEngine;

[CreateAssetMenu(fileName = "New Variable Transfer Object", menuName = "Scriptable Assets/Options/Variable Transfer")]
public class ScriptableVariableTransferObject : ScriptableObject
{
    public bool m_MouseControls;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        m_MouseControls = false;
    }
}
