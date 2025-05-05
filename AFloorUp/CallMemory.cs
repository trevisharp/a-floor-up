using System;
using System.Linq;
using System.Collections.Generic;

namespace AFloorUp;

public class CallMemory
{
    int nextItemId = 1;
    readonly Dictionary<int, CallInfo> calls = [];

    public void Add(CallInfo callInfo)
    {
        calls.Add(nextItemId, callInfo);
        nextItemId++;
    }

    public void Remove(int id)
    {
        if (!calls.ContainsKey(id))
            throw new Exception($"The 'id' {id} does not exist in memory.");
        calls.Remove(id);
    }

    public IEnumerable<(int id, CallInfo info)> All =>
        from keyPair in calls.ToArray()
        let id = keyPair.Key
        let info = keyPair.Value
        select (id, info);
}