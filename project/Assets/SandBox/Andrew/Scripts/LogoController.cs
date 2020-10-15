using UnityEngine;

public class LogoController : MonoBehaviour
{
    [SerializeField] float m_targetTime;

    float m_elapsedTime;
    private void OnEnable()
    {
        m_elapsedTime = 0f;
    }
    void Update()
    {
        m_elapsedTime += Time.deltaTime;
        if(m_elapsedTime >= m_targetTime)
        {
            //load menu screen
        }
    }
}
