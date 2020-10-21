using System;
using System.IO;
using UnityEngine;
public abstract class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] private T m_value;
    [NonSerialized] public T m_Value;
    private void OnEnable() => Reset();

    public void Reset() => m_Value = m_value;
}
