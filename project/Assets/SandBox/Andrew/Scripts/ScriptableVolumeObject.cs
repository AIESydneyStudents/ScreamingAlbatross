using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Volume Object", menuName = "Scriptable Assets/Options/Volume Object")]
public class ScriptableVolumeObject : ScriptableObject
{
    public float m_Master;
    public float m_SFX;
    public float m_Music;
}
