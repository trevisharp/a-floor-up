namespace AFloorUp.CallPanels;

public class SimpleCallPanel(Memory<CallInfo> memory) : CallPanel(memory)
{
    public override void Call(int targetFloor)
    {
        if (Floor == targetFloor)
            return;
        
        var call = new CallInfo(Floor, Direction.Unknow);
        Memory.Add(call);
    }
}