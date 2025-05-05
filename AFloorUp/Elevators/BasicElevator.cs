using System;

using Radiance;
using Radiance.Bufferings;
using static Radiance.Utils;

namespace AFloorUp.Elevators;

/// <summary>
/// A basic and cheap elevator for small business.
/// A slow elevator (0.25) with imprecise decision moment and
/// low decision frequency (4Hz). Open the door for 5 seconds.
/// </summary>
public class BasicElevator(
    int id,
    ElevatorLogic logic,
    Memory<CallInfo> callMemory,
    Memory<RequestInfo> requestMemory
    ) : Elevator(id, logic, callMemory, requestMemory)
{
    const float speed = 0.25f;
    int target = 0;
    float t = 0f;
    float doorOpenWaiting = 0;
    bool waiting = true;

    dynamic shaftRender = render(() =>
    {
        color = vec(1f, 0.8f, 0.8f, 1f);
        fill();

        color = black;
        draw(3);
    });

    dynamic elevatorRender = render((val y) =>
    {
        move(0, y, 500);
        color = vec(0.6f, 0.48f, 0.48f, 1f);
        fill();

        color = black;
        draw(1f);
    });
    float floorHei = 0;
    (float x, float y, float areaWidth, float areaHeight)? drawArea = null;
    Polygon? shaftPoly = null;
    Polygon? elevatorPoly = null;

    public override void Draw()
    {
        if (drawArea is null)
            throw new Exception($"A elevator needs a draw area.");
        
        shaftRender(shaftPoly);
        elevatorRender(elevatorPoly, YPosition * floorHei);
    }

    public override void SetDrawInfo(float x, float y, float areaWidth, float areaHeight, int floors)
    {
        if (areaWidth <= 0 || areaHeight <= 0)
            throw new Exception($"Invalida area rect({x}, {y}, {areaWidth}, {areaHeight})");
        
        drawArea = (x, y, areaWidth, areaHeight);
        shaftPoly = Polygons.Rect(x, y, 0, areaWidth, areaHeight);
        floorHei = areaHeight / floors;
        elevatorPoly = Polygons.Rect(x + 0.5f, y - floorHei * (floors - 1), 0, areaWidth * 0.9f, floorHei);
    }

    public override void Simulate(float dt)
    {
        t += dt;
        if (t >= 0.25f)
        {
            t = 0f;
            var control = GetController();
            control.Target = target;
            Logic.Decide(control);
            target = control.Target;
        }

        if (doorOpenWaiting > 0)
        {
            doorOpenWaiting -= dt;
            return;
        }

        if (DoorIsOpen)
        {
            DoorIsOpen = false;
            waiting = true;
        }

        if (target > YPosition)
            YPosition += speed * dt;

        if (target < YPosition)
            YPosition -= speed * dt;

        var diff = float.Abs(target - YPosition);
        if (diff < 0.1 && !waiting)
        {
            YPosition = target;
            DoorIsOpen = true;
            doorOpenWaiting = 5f;
        }
        else if (diff > 0.1)
        {
            waiting = false;
        }
    }
}