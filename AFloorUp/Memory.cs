using System;
using System.Linq;
using System.Collections.Generic;

namespace AFloorUp;

public class Memory<T>
{
    int nextItemId = 1;
    readonly Dictionary<int, T> requests = [];

    public void Add(T info)
    {
        requests.Add(nextItemId, info);
        nextItemId++;
    }

    public void Remove(int id)
    {
        if (!requests.ContainsKey(id))
            throw new Exception($"The 'id' {id} does not exist in memory.");
        requests.Remove(id);
    }

    public IEnumerable<(int id, T info)> All =>
        from keyPair in requests.ToArray()
        let id = keyPair.Key
        let info = keyPair.Value
        select (id, info);
}