using System;

public interface INotifyCollectionChangedOfT<T>
{
    event Action<int, T> ItemAdded;
    event Action<int, T> ItemRemoved;
    event Action<int, T> ItemChanged;
    event Action CollectionChanged;
}