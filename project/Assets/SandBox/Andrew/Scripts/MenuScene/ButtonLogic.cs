using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Text m_text;
    [SerializeField] Image m_image;
    [SerializeField] Color m_highlightColor;
    [SerializeField] MenuButtons m_button;
    [SerializeField] ScriptableButtonEnum m_buttonTransferObject;
    [SerializeField] GameEvent m_buttonClicked;
    [SerializeField] GameEvent m_mouseOverEvent;
    [SerializeField] ScriptableAudioClip m_audioTransferVariable;
    [SerializeField] AudioClip m_clickSound;
    [SerializeField] AudioClip m_mouseOverSound;
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
        m_audioTransferVariable.m_Value = m_mouseOverSound;
        m_mouseOverEvent.Raise();

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        m_text.color = m_defaultColour;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_text.color = m_defaultColour;
        m_buttonTransferObject.m_Value = m_button;
        m_audioTransferVariable.m_Value = m_clickSound;
        m_buttonClicked.Raise();
    }
}
