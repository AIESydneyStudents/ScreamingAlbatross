using UnityEngine;

public class BridgeCustomerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] m_customerList;

    private void OnEnable()
    {
        if (Random.Range(0, 4) == 0)
        {
            Instantiate(m_customerList[Random.Range(0, m_customerList.Length)], transform.position, Quaternion.identity);
        }
    }
}