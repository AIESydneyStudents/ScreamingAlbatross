﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Text m_text;
    [SerializeField] Color m_highlightColor;
    [SerializeField] MenuButtons m_button;
    [SerializeField] ScriptableButtonEnum m_buttonTransferObject;
    [SerializeField] GameEvent m_buttonClicked;
    [SerializeField] ScriptableAudioClip m_audioTransferVariable;
    [SerializeField] AudioClip m_myClip;
    Color m_defaultColour;
    private void OnEnable()
    {
        m_defaultColour = m_text.color;
    }
    private void OnDisable()
    {
        m_defaultColour = Color.white;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_text.color = m_highlightColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        m_text.color = m_defaultColour;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_text.color = m_defaultColour;
        m_buttonTransferObject.m_Value = m_button;
        //m_audioTransferVariable.m_Value = m_myClip;
        m_buttonClicked.Raise();
    }
}
