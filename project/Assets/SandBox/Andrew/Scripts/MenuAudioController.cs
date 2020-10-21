using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    [SerializeField] ScriptableAudioClip m_audioTransferVariable;
    [SerializeField] AudioSource m_source;

    public void PlayClip()
    {
        m_source.PlayOneShot(m_audioTransferVariable.m_Value);
    }
}