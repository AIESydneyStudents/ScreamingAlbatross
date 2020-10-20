using UnityEngine;
using UnityEngine.UI;
public class LogoTextRandomizer : MonoBehaviour
{
    [SerializeField] Text m_funnyText;

    [SerializeField] string[] m_texts;
    private void OnEnable()
    {
        m_funnyText.text = m_texts[Random.Range(0, m_texts.Length)];
    }
}