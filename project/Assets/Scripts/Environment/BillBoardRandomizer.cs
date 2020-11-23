using UnityEngine;

public class BillBoardRandomizer : MonoBehaviour
{
    [SerializeField] MeshRenderer m_myRenderer;
    [SerializeField] Material[] m_possibleMats;

    private void OnEnable()
    {
        m_myRenderer.material = m_possibleMats[Random.Range(0, m_possibleMats.Length)];
    }
}