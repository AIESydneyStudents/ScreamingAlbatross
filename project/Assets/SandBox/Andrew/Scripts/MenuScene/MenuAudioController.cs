using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    [SerializeField] ScriptableAudioClip m_audioTransferVariable;
    [SerializeField] AudioSource m_musicSource;
    [SerializeField] AudioSource m_SFXSource;
    [SerializeField] ScriptableVolumeObject m_volumeTransferObject;
    [SerializeField] ScriptableAudioClipRunTimeSet m_musicClips;
    private float m_musicElapsed, m_musicTarget;
    private void OnEnable()
    {
        m_musicElapsed = m_musicTarget = 0f;
        UpdateVolume();
        MusicPlay();
    }

    private void FixedUpdate()
    {
        m_musicElapsed += Time.fixedDeltaTime;
        if(m_musicElapsed >= m_musicTarget)
        {
            m_musicElapsed = 0f;
            MusicPlay();
        }
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

    public void MusicPlay()
    {
        m_musicSource.clip = m_musicClips.GetRandomItem();
        m_musicTarget = m_musicSource.clip.length;
        m_musicSource.Play();
    }
}