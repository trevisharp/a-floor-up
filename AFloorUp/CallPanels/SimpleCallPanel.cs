namespace AFloorUp.CallPanels;

public class SimpleCallPanel(int floor, Memory<CallInfo> memory) : CallPanel(floor, memory)
{
    public override void Call(int targetFloor)
    {
        if (Floor == targetFloor)
            return;
        
        var call = new CallInfo(Floor, Direction.Unknow);
        Memory.Add(call);
    }
}