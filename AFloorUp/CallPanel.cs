namespace AFloorUp;

using CallPanels;

public abstract class CallPanel(int floor, Memory<CallInfo> memory)
{
    public readonly int Floor = floor;
    public readonly Memory<CallInfo> Memory = memory;
    
    public abstract void Call(int targetFloor);

    public static CallPanel Simple(int floor, Memory<CallInfo> memory)
        => new SimpleCallPanel(floor, memory);

    public static CallPanel WithDirection(int floor, Memory<CallInfo> memory)
        => new DirectionCallPanel(floor, memory);
}