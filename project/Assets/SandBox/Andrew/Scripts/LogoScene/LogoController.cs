using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviour
{
    [SerializeField] float m_targetTime;
    [SerializeField] GameObject[] m_textObjects;
    [SerializeField] GameObject[] m_revealObject;
    [SerializeField] float[] m_revealObjectDelays;
    [SerializeField] ScriptableVolumeObject m_volumeTransferObject;
    [SerializeField] AudioSource m_source;

    float m_elapsedTime;
    int m_revealIndex;
    private void OnEnable()
    {
        m_elapsedTime = 0f;
        m_revealIndex = 0;
        m_source.volume = m_volumeTransferObject.m_Master * m_volumeTransferObject.m_Music;
    }
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if(m_elapsedTime >= m_revealObjectDelays[m_revealIndex])
        {
            m_textObjects[m_revealIndex].SetActive(true);
            m_revealObject[m_revealIndex].SetActive(true);

            if(m_revealIndex == 1)
                m_source.Play();

            m_revealIndex++;
        }


        if(m_elapsedTime >= m_targetTime || Input.GetKeyDown(KeyCode.Escape))
        {
            //load menu screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
