using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float m_rotationSpeed;
    [SerializeField] Vector3 m_rotateDirection;

    private void Update()
    {
        transform.Rotate(m_rotateDirection * m_rotationSpeed * Time.deltaTime);
    }
}