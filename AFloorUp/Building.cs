using System;
using System.Collections.Generic;

using Radiance;

namespace AFloorUp;

/// <summary>
/// Represents a generic Building with floors and elevators.
/// </summary>
public class Building
{
    public int Floors { get; private set; } = 0;
    public int Elevators { get; private set; } = 0;

    readonly List<Elevator> elevators = [];
    readonly Dictionary<int, CallPanel> floors = [];

    public void AddElevator(Elevator elevator)
    {
        Elevators++;
        elevators.Add(elevator);
    }

    public void AddFloor(CallPanel callPanel)
    {
        Floors++;
        floors.Add(Floors, callPanel);
    }

    public CallPanel GetPanel(int floor)
    {
        if (floors.TryGetValue(floor, out var panel))
            return panel;
        
        throw new Exception($"Invalid floor {floor}");
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}