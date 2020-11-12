using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Sound Object", menuName = "Scriptable Assets/Sounds/Clips")]
public class ScriptableSoundObject : ScriptableObject
{
    [SerializeField] AudioClip[] m_clips;
    [SerializeField] ScriptableAudioClip m_toPlay;
    [SerializeField] GameEvent m_playOneShot;

    public void Play()
    {
        m_toPlay.m_Value = m_clips[Random.Range(0, m_clips.Length)];
        m_playOneShot.Raise();
    }
}