namespace AFloorUp;

public abstract class Elevator(
    int id,
    ElevatorLogic logic,
    Memory<CallInfo> callMemory,
    Memory<RequestInfo> requestMemory
    )
{
    public readonly int Id = id;
    public readonly Memory<CallInfo> CallMemory = callMemory;
    public readonly Memory<RequestInfo> RequestMemory = requestMemory;
    public readonly ElevatorLogic Logic = logic;
    public int CurrentFloor { get; internal set; }

    public abstract void Simulate(float dt);
    public abstract void Draw(float x, float y, float widArea, float heiArea);
}