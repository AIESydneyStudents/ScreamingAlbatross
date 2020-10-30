using UnityEngine;

public class TestBlockTranslation : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;
    [SerializeField] Vector3 m_moveDir;
    private void FixedUpdate()
    {
        transform.Translate(m_moveDir * m_moveSpeed * Time.fixedDeltaTime);
    }
}
