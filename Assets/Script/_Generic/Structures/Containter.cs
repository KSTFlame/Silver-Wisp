using System.Collections.Generic;
using System;
using UnityEngine;

public class Containter<T> : MonoBehaviour
{
    [SerializeField]
    private List<T> _items = new List<T>();
    [SerializeField]
    protected int MaxSize;
    
    public bool IsFull => _items.Count >= MaxSize;
    public bool IsEmpty => _items.Count <= 0;
    public int Count => _items.Count;
    
    public event Action<T, int, int> OnItemAdded;
    public event Action<T, int, int> OnItemRemoved;
    public event Action<int, int> OnClearedList;

    /// <summary>
    /// Adds an item to the container.
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        if (IsFull) return;
        _items.Add(item);
        OnItemAdded?.Invoke(item, Count, MaxSize);
    }
    
    /// <summary>
    /// Removes and item from the container.
    /// </summary>
    /// <param name="item"></param>
    public void Remove(T item)
    {
        if (IsEmpty) return;
        _items.Remove(item);
        OnItemRemoved?.Invoke(item, Count, MaxSize);
    }

    /// <summary>
    /// Cleats the items list.
    /// </summary>
    public void Clear()
    {
        _items.Clear();
        OnClearedList?.Invoke(Count, MaxSize);
    }
}
