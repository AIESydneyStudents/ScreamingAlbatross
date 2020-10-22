using UnityEngine;

public class MenuCarLogic : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;
    Vector3 m_start, m_end;

    private void OnEnable()
    {
        transform.position = m_start;
        transform.LookAt(m_end);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_end, m_moveSpeed * Time.deltaTime);
        if (transform.position == m_end)
            gameObject.SetActive(false);
    }
    public void InitializeCar(Vector3 start, Vector3 end)
    {
        m_start = new Vector3(start.x, transform.position.y, start.z);
        m_end = new Vector3(end.x, transform.position.y, end.z);
        gameObject.SetActive(true);
    }
}