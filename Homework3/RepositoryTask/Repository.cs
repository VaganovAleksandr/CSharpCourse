using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> where T : IEntity
{
    private readonly Dictionary<int, T> _storage = new Dictionary<int, T>();

    public int Count => _storage.Count;

    public void Add(T item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"Element with id={item.Id} already exists");
        }
        _storage.Add(item.Id, item);
    }

    public bool Remove(int id)
    {
        return _storage.Remove(id);
    }

    public T? GetById(int id)
    {
        return _storage.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return _storage.Values.ToList().AsReadOnly();
    }

    public IReadOnlyList<T> Find(Predicate<T> predicate)
    {
        return _storage.Values.Where(item => predicate(item)).ToList().AsReadOnly();
    }
}
