using System;

namespace AFloorUp.Logics;

public class LambdaElevatorLogic(Action<ElevatorController> function) : ElevatorLogic
{
    public override void Decide(ElevatorController elevator)
        => function?.Invoke(elevator);
}