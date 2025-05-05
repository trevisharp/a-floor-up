namespace AFloorUp;

using CallPanels;

public abstract class CallPanel(int floor, CallMemory memory)
{
    public readonly int Floor = floor;
    public readonly CallMemory Memory = memory;
    
    public abstract void Call(int targetFloor);

    public static CallPanel Simple(int floor, CallMemory memory)
        => new SimpleCallPanel(floor, memory);

    public static CallPanel Direction(int floor, CallMemory memory)
        => new DirectionCallPanel(floor, memory);
}