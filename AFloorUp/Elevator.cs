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

    public float YPosition { get; protected set; } = 0f;
    public bool DoorIsOpen { get; protected set; } = false;

    public abstract void Draw();
    public abstract void Simulate(float dt);
    public abstract void SetDrawInfo(float x, float y, float areaWidth, float areaHeight, int floors);

    protected ElevatorController GetController()
    {
        return new ElevatorController {
            Id = Id,
            YPosition = YPosition,
            CallMemory = CallMemory,
            RequestMemory = RequestMemory,
            DoorIsOpen = DoorIsOpen
        };
    }
}