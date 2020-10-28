using UnityEngine;

public class LogoScreenMove : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.right * m_moveSpeed * Time.deltaTime);
    }
}