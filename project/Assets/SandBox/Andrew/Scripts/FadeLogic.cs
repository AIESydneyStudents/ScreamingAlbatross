using UnityEngine;
using UnityEngine.UI;

public class FadeLogic : MonoBehaviour
{
    [SerializeField] float m_fadeSpeed;
    [SerializeField] Image m_image;

    bool m_run;

    private void OnEnable()
    {
        m_run = true;
    }
    //fade in for logo
    private void Update()
    {
        if(m_run)
        {
            if (m_image != null)
            {
                m_image.color = UpdateAlpha(m_image.color);
            }
        }
    }

    Color UpdateAlpha(Color c)
    {
        c.a += m_fadeSpeed * Time.deltaTime;
        if (c.a >= 1f)
        {
            m_run = false;
        }
        return c;
    }
}
