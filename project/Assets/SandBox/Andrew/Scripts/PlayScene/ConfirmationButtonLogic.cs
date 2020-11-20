using UnityEngine;

public class ConfirmationButtonLogic : MonoBehaviour
{
    [SerializeField] AudioClip m_buttonClick;
    [SerializeField] ScriptableAudioClip m_transferObject;

    public void SetClick()
    {
        m_transferObject.m_Value = m_buttonClick;
    }
}