using System.Collections.Generic;
using UnityEngine;

public class TestBlockSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> m_spawnObjects;

    private void OnEnable()
    {
        Spawn();
    }
    private void OnTriggerExit(Collider other)
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(m_spawnObjects[Random.Range(0, m_spawnObjects.Count)], transform.position, Quaternion.identity);
    }
}