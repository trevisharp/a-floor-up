using System;

namespace AFloorUp;

using Logics;

public abstract class ElevatorLogic
{
    public abstract void Decide(ElevatorController elevator);

    public static ElevatorLogic FromFunction(Action<ElevatorController> logic)
        => new LambdaElevatorLogic(logic);
}