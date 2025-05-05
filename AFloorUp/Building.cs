using System;
using System.Collections.Generic;

using Radiance;
using static Radiance.Utils;

namespace AFloorUp;

/// <summary>
/// Represents a generic Building with floors and elevators.
/// </summary>
public class Building
{
    public int Floors { get; private set; } = 0;
    public int Elevators { get; private set; } = 0;

    readonly List<Elevator> elevators = [];
    readonly Dictionary<int, CallPanel[]> floors = [];

    public void AddElevator(Elevator elevator)
    {
        Elevators++;
        elevators.Add(elevator);
    }

    public void AddFloor(params CallPanel[] callPanel)
    {
        Floors++;
        floors.Add(Floors, callPanel);
    }

    public CallPanel[] GetPanels(int floor)
    {
        if (floors.TryGetValue(floor, out var panel))
            return panel;
        
        throw new Exception($"Invalid floor {floor}");
    }

    public void SetDrawInfo(float x, float y, float areaWidth, float areaHeight)
    {
        const float pad = 80;
        floorHei = areaHeight * .9f / Floors;
        baseX = x;
        baseY = y - areaHeight * .05f;
        wid = areaWidth;

        float elevatorHei = areaHeight * .9f;
        float elevatorWid = floorHei * .8f;
        
        x += pad;
        foreach (var elevator in elevators)
        {
            elevator.SetDrawInfo(x, baseY, elevatorWid, elevatorHei, Floors);
            x += elevatorWid + pad;
        }
    }

    float floorHei = 0f;
    float wid = 0f;
    float baseY = 0f;
    float baseX = 0f;
    readonly dynamic floorRender = render((val px, val py, val wid, val hei) =>
    {
        pos = (pos.x * wid, pos.y * hei, pos.z);
        move(px + wid / 2, py + hei / 2, 20);

        color = (0.2f, 0.0f, 0.0f, 1.0f);
        fill();
    });

    public void Draw()
    {
        for (int j = 0; j < Floors + 1; j++)
            floorRender(Polygons.Square, baseX, baseY - j * floorHei, wid, 10);

        foreach (var elevator in elevators)
            elevator.Draw();
    }

    public void Simulate(float dt)
    {
        foreach (var elevator in elevators)
            elevator.Simulate(dt);
    }
}