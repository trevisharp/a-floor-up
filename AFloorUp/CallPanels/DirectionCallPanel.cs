namespace AFloorUp.CallPanels;

public class DirectionCallPanel(Memory<CallInfo> memory) : CallPanel(memory)
{
    public override void Call(int targetFloor)
    {
        if (Floor == targetFloor)
            return;
        
        var direction = 
            targetFloor > Floor ? 
            Direction.Up : 
            Direction.Down;
        
        var call = new CallInfo(Floor, direction);
        Memory.Add(call);
    }
}