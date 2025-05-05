namespace AFloorUp.Buildings;

using Elevators;

public class Level2Building : Building
{
    public Level2Building(ElevatorLogic logic)
    {
        var callMemory1 = new Memory<CallInfo>();
        var reqsMemory1 = new Memory<RequestInfo>();
        var elevator1 = new BasicElevator(
            1, logic,
            callMemory1,
            reqsMemory1
        );
        
        var callMemory2 = new Memory<CallInfo>();
        var reqsMemory2 = new Memory<RequestInfo>();
        var elevator2 = new BasicElevator(
            2, logic,
            callMemory2,
            reqsMemory2
        );

        AddElevator(elevator1);
        AddElevator(elevator2);
        for (int i = 0; i < 6; i++)
        AddFloor(CallPanel.Simple(callMemory1), CallPanel.Simple(callMemory2));
    }
}