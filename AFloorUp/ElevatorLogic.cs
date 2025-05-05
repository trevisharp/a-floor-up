using System;

namespace AFloorUp;

using Logics;

public abstract class ElevatorLogic
{
    public abstract void Decide(ElevatorControl elevator);

    public static ElevatorLogic FromFunction(Action<ElevatorControl> logic)
        => new LambdaElevatorLogic(logic);
}