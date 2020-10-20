using UnityEngine;

public class LogoController : MonoBehaviour
{
    [SerializeField] float m_targetTime;
    [SerializeField] GameObject[] m_textObjects;
    [SerializeField] GameObject[] m_revealObject;
    [SerializeField] float[] m_revealObjectDelays;

    float m_elapsedTime;
    int m_revealIndex;
    private void OnEnable()
    {
        m_elapsedTime = 0f;
        m_revealIndex = 0;
    }
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if(m_elapsedTime >= m_revealObjectDelays[m_revealIndex])
        {
            m_textObjects[m_revealIndex].SetActive(true);
            m_revealObject[m_revealIndex].SetActive(true);

            m_revealIndex++;
        }


        if(m_elapsedTime >= m_targetTime)
        {
            //load menu screen
        }
    }
}
