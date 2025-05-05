using System;

namespace AFloorUp.Logics;

public class LambdaElevatorLogic(Action<ElevatorControl> function) : ElevatorLogic
{
    public override void Decide(ElevatorControl elevator)
        => function?.Invoke(elevator);
}