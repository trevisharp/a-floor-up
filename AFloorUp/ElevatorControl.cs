namespace AFloorUp;

public class ElevatorControl(int currTarget)
{
    public int CurrentTarget { get; private set; } = currTarget;
    public required Memory<CallInfo> CallMemory { get; init; }
    public required Memory<RequestInfo> RequestMemory { get; init; }

    public void MoveTo(int target)
        => CurrentTarget = target;
}