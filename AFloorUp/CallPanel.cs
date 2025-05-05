namespace AFloorUp;

using CallPanels;

public abstract class CallPanel(Memory<CallInfo> memory)
{
    public int Floor { get; set; }
    public readonly Memory<CallInfo> Memory = memory;
    
    public abstract void Call(int targetFloor);

    public static CallPanel Simple(Memory<CallInfo> memory)
        => new SimpleCallPanel(memory);

    public static CallPanel WithDirection(Memory<CallInfo> memory)
        => new DirectionCallPanel(memory);
}