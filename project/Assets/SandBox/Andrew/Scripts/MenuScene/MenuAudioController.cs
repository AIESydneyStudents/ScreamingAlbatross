using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    [SerializeField] ScriptableAudioClip m_audioTransferVariable;
    [SerializeField] AudioSource m_musicSource;
    [SerializeField] AudioSource m_SFXSource;
    [SerializeField] ScriptableVolumeObject m_volumeTransferObject;

    private void OnEnable()
    {
        UpdateVolume();
        m_musicSource.Play();
    }

    public void UpdateVolume()
    {
        m_SFXSource.volume = m_volumeTransferObject.m_Master * m_volumeTransferObject.m_SFX;
        m_musicSource.volume = m_volumeTransferObject.m_Master * m_volumeTransferObject.m_Music;
    }

    public void PlayClip()
    {
        m_SFXSource.PlayOneShot(m_audioTransferVariable.m_Value);
    }
}