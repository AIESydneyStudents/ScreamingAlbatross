using UnityEngine;
using UnityEngine.UI;
public class MenuSoundAdjustLogic : MonoBehaviour
{
    [SerializeField] ScriptableVolumeObject m_volumeObject;
    [SerializeField] Slider m_silder;
    [SerializeField] MenuButtons m_soundType;

    private void OnEnable()
    {
        switch(m_soundType)
        {
            case MenuButtons.MasterVolume:
                m_silder.value = m_volumeObject.m_Master;
                break;
            case MenuButtons.SFXVolume:
                m_silder.value = m_volumeObject.m_SFX;
                break;
            case MenuButtons.MusicVolume:
                m_silder.value = m_volumeObject.m_Music;
                break;
            case MenuButtons.None:
                break;
        }
    }
    public void UpdateVolume()
    {
        switch(m_soundType)
        {
            case MenuButtons.MasterVolume:
                m_volumeObject.m_Master = m_silder.value;
                break;
            case MenuButtons.MusicVolume:
                m_volumeObject.m_Music = m_silder.value;
                break;
            case MenuButtons.SFXVolume:
                m_volumeObject.m_SFX = m_silder.value;
                break;
            case MenuButtons.None:
                break;
        }
    }
}