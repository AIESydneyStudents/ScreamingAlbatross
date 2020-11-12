using System.Collections.Generic;
using UnityEngine;
public abstract class RunTimeSet<T> : ScriptableObject
{
    [SerializeField] private List<T> items = new List<T>();
    public void Initialize() => items.Clear();
    public int ListCount()
    {
        return items.Count;
    }
    public T GetItemIndex(int index)
    {
        return items[index];
    }
    public void AddToList(T thingToAdd)
    {
        if (!items.Contains(thingToAdd))
            items.Add(thingToAdd);
    }
    public void RemoveFromList(T thingToRemove)
    {
        if (items.Contains(thingToRemove))
            items.Remove(thingToRemove);
    }
    public T GetRandomItem()
    {
        return items[Random.Range(0, items.Count)];
    }
    //[CreateAssetMenu(fileName = "New ... RunTimeSet", menuName = "Scriptable Assets/RunTimeSet/ ... ")]
}
