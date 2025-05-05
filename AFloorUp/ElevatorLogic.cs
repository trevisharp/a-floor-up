using System;

namespace AFloorUp;

using Logics;

public abstract class ElevatorLogic
{
    public abstract void Decide(Elevator elevator);

    public static ElevatorLogic FromFunction(Action<Elevator> logic)
        => new LambdaElevatorLogic(logic);
}