using System;

namespace AFloorUp.Logics;

public class LambdaElevatorLogic(Action<Elevator> function) : ElevatorLogic
{
    public override void Decide(Elevator elevator)
        => function?.Invoke(elevator);
}